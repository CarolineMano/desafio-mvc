using System.Linq;
using DESAFIO.MVC.Data;
using DESAFIO.MVC.DTO;
using DESAFIO.MVC.Models;
using DESAFIO.MVC.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DESAFIO.MVC.Controllers
{
    public class DailiesController : Controller
    {
        private readonly ApplicationDbContext _database;
        private readonly UserManager<IdentityUser> _userManager;
        public DailiesController(ApplicationDbContext database, UserManager<IdentityUser> userManager)
        {
            _database = database;
            _userManager = userManager;
        }
        [HttpPost]
        public IActionResult Save(DailyDTO tempDaily)
        {
            if(ModelState.IsValid)
            {
            Daily newDaily = new Daily();
            newDaily.Id = tempDaily.Id;
            newDaily.Date = tempDaily.Date;
            newDaily.TasksDoing = tempDaily.TasksDoing;
            newDaily.TasksDone = tempDaily.TasksDone;
            newDaily.Impediments = tempDaily.Impediments;
            newDaily.Presence = tempDaily.Presence;
            newDaily.ModuleId = tempDaily.ModuleID;
            newDaily.Module = _database.Modules.First(module => module.Id == tempDaily.ModuleID);
            newDaily.StarterId = tempDaily.StarterID;
            newDaily.Starter = _database.Starters.First(starter => starter.Id == tempDaily.StarterID);
            newDaily.Status = true;

            _database.Dailies.Add(newDaily);
            _database.SaveChanges();

            return RedirectToAction("Dailies", "Management");
            }
            ViewBag.Modules = _database.Modules.Where(module => module.Status == true).ToList();
            ViewBag.Starters = UserBasedList.GetStartersBasedOnRole(_userManager.GetUserId(User), _database);
            return View("../Management/NewDaily");
        }
        [HttpPost]
        public IActionResult Update(DailyDTO tempDaily)
        {
            if(ModelState.IsValid)
            {
                var daily = _database.Dailies.First(daily => daily.Id == tempDaily.Id);
                daily.Id = tempDaily.Id;
                daily.Date = tempDaily.Date;
                daily.TasksDoing = tempDaily.TasksDoing;
                daily.TasksDone = tempDaily.TasksDone;
                daily.Impediments = tempDaily.Impediments;
                daily.Presence = tempDaily.Presence;
                daily.ModuleId = tempDaily.ModuleID;
                daily.Module = _database.Modules.First(module => module.Id == tempDaily.ModuleID);
                daily.StarterId = tempDaily.StarterID;
                daily.Starter = _database.Starters.First(starter => starter.Id == tempDaily.StarterID);

                _database.SaveChanges();
                return RedirectToAction("Dailies", "Management");
            }
            ViewBag.Modules = _database.Modules.Where(module => module.Status == true).ToList();
            ViewBag.Starters = UserBasedList.GetStartersBasedOnRole(_userManager.GetUserId(User), _database);
            return View("../Management/EditDaily");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if(id > 0)
            {
                var daily = _database.Dailies.First(daily => daily.Id == id);
                daily.Status = false;
                _database.SaveChanges();
            }
            return RedirectToAction("Dailies", "Management");
        }
    }
}