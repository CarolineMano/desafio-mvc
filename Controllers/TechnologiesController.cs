using System.Linq;
using DESAFIO.MVC.Data;
using DESAFIO.MVC.DTO;
using DESAFIO.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DESAFIO.MVC.Controllers
{
    public class TechnologiesController : Controller
    {
        private readonly ApplicationDbContext _database;
        public TechnologiesController(ApplicationDbContext database)
        {
            _database = database;
        }
        [HttpPost]
        public IActionResult Save(TechnologyDTO tempTechnology)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var technologyFromDb = _database.Technologies.First(technology => technology.Name == tempTechnology.Name);
                    if(technologyFromDb.Status == false)
                    {
                        technologyFromDb.Description = tempTechnology.Description;
                        technologyFromDb.Status = true;
                        _database.SaveChanges();
                        return RedirectToAction("Technologies", "Management");
                    }
                    else
                    {
                        return View("../Management/Error", "an active Technology with this name");  
                    }
                    
                }
                catch (System.Exception)
                {                    
                    Technology newTechnology = new Technology();
                    newTechnology.Name = tempTechnology.Name;
                    newTechnology.Description = tempTechnology.Description;
                    newTechnology.Status = true;

                    _database.Technologies.Add(newTechnology);
                    _database.SaveChanges();
                    
                    return RedirectToAction("Technologies", "Management");
                }   
            }
            return View("../Management/NewTechnology");            
        }

        [HttpPost]
        public IActionResult Update(TechnologyDTO tempTechnology)
        {
            if(ModelState.IsValid)
            {
                var technology = _database.Technologies.First(technology => technology.Id == tempTechnology.Id);
                try
                {
                    var technologyFromDb = _database.Technologies.First(technology => technology.Name == tempTechnology.Name && technology.Id != tempTechnology.Id);
                    if(technologyFromDb.Status == false)
                    {
                        technologyFromDb.Description = tempTechnology.Description;
                        technologyFromDb.Status = true;
                        technology.Status = false;
                        _database.SaveChanges();
                        return RedirectToAction("Technologies", "Management");
                    } 
                    else
                    {
                        return View("../Management/Error", "an active Technology with the name you're trying to update to"); 
                    }
                }
                catch (System.Exception)
                {
                    technology.Name = tempTechnology.Name;
                    technology.Description = tempTechnology.Description;
                    _database.SaveChanges();
                    return RedirectToAction("Technologies", "Management");
                }
                
            }
            return View("../Management/EditTechnology");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if(id > 0)
            {
                var technology = _database.Technologies.First(technology => technology.Id == id);
                technology.Status = false;
                _database.SaveChanges();
            }
            return RedirectToAction("Technologies", "Management");
        }
    }
}