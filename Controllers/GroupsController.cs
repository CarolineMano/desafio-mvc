using System.Linq;
using DESAFIO.MVC.Data;
using DESAFIO.MVC.DTO;
using DESAFIO.MVC.Models;
using DESAFIO.MVC.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace DESAFIO.MVC.Controllers
{
    public class GroupsController : Controller
    {
        private readonly ApplicationDbContext _database;
        public GroupsController(ApplicationDbContext database)
        {
            _database = database;
        }
        [HttpPost]
        public IActionResult Save(GroupDTO tempGroup)
        {
            if(ModelState.IsValid)
            {
                Group newGroup = new Group();
                newGroup.TechnologyId = tempGroup.TechnologyID;
                newGroup.Technology = _database.Technologies.First(technology => technology.Id == tempGroup.TechnologyID);
                newGroup.ScrumMaster = tempGroup.ScrumMaster;
                newGroup.Status = true;

                _database.Groups.Add(newGroup);
                _database.SaveChanges();

                return RedirectToAction("Groups", "Management");
            }
            else
            {
                ViewBag.StartPrograms = _database.StartPrograms.Where(program => program.Status == true).ToList();
                ViewBag.Technologies = _database.Technologies.Where(technology => technology.Status == true).ToList();
                ViewBag.ScrumMasters = UserBasedList.GetScrumMasters(_database);
                return View("../Management/NewGroup");
            }
        }
        [HttpPost]
        public IActionResult Update(GroupDTO tempGroup)
        {
            if(ModelState.IsValid)
            {
                var group = _database.Groups.First(group => group.Id == tempGroup.Id);
                group.TechnologyId = tempGroup.TechnologyID;
                group.Technology = _database.Technologies.First(technology => technology.Id == tempGroup.TechnologyID);
                group.ScrumMaster = tempGroup.ScrumMaster;
                _database.SaveChanges();
                return RedirectToAction("Groups", "Management");
            }
                ViewBag.StartPrograms = _database.StartPrograms.Where(program => program.Status == true).ToList();
                ViewBag.Technologies = _database.Technologies.Where(technology => technology.Status == true).ToList();
                ViewBag.ScrumMasters = UserBasedList.GetScrumMasters(_database);
            return View("../Management/EditGroup");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if(id > 0)
            {
                var group = _database.Groups.First(group => group.Id == id);
                group.Status = false;
                _database.SaveChanges();
            }
            return RedirectToAction("Groups", "Management");
        }
    }
}