using System.Linq;
using DESAFIO.MVC.Data;
using DESAFIO.MVC.DTO;
using DESAFIO.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DESAFIO.MVC.Controllers
{
    public class ModulesController : Controller
    {
        private readonly ApplicationDbContext _database;
        public ModulesController(ApplicationDbContext database)
        {
            _database = database;
        }
        [HttpPost]
        public IActionResult Save(ModuleDTO tempModule)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var moduleFromDb = _database.Modules.First(module => module.Name == tempModule.Name);
                    if(moduleFromDb.Status == false)
                    {
                        moduleFromDb.Status = true;
                        _database.SaveChanges();
                        return RedirectToAction("Modules", "Management");
                    }
                    else
                    {
                        return View("../Management/Error", "an active Module with this name"); 
                    }
                }
                catch (System.Exception)
                {    
                    Module newModule = new Module();
                    newModule.Id = tempModule.Id;
                    newModule.Name = tempModule.Name;
                    newModule.Status = true;

                    _database.Modules.Add(newModule);
                    _database.SaveChanges();
                    
                    return RedirectToAction("Modules", "Management");
                }

            }
            return View("../Management/NewModule");
        }
        [HttpPost]
        public IActionResult Update(ModuleDTO tempModule)
        {
            if(ModelState.IsValid)
            {   
                var module = _database.Modules.First(module => module.Id == tempModule.Id);
                try
                {
                    var moduleFromDb = _database.Modules.First(module => module.Name == tempModule.Name && module.Id != tempModule.Id);
                    if(moduleFromDb.Status == false)
                    {
                        moduleFromDb.Status = true;
                        module.Status = false;
                        _database.SaveChanges();
                        return RedirectToAction("Modules", "Management");
                    }
                    else
                    {
                        return View("../Management/Error", "an active Module with the name you're trying to update to"); 
                    }
                }
                catch (System.Exception)
                {                    
                    module.Name = tempModule.Name;
                    _database.SaveChanges();
                    return RedirectToAction("Modules", "Management");
                }
                
            }
            return View("../Management/EditModule");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if(id > 0)
            {
                var module = _database.Modules.First(module => module.Id == id);
                module.Status = false;
                _database.SaveChanges();
            }
            return RedirectToAction("Modules", "Management");
        }
    }
}