using System.Linq;
using DESAFIO.MVC.Data;
using DESAFIO.MVC.DTO;
using DESAFIO.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DESAFIO.MVC.Controllers
{
    public class StartProgramsController : Controller
    {
        private readonly ApplicationDbContext _database;
        public StartProgramsController(ApplicationDbContext database)
        {
            _database = database;
        }
        [HttpPost]
        public IActionResult Save(StartProgramDTO tempProgram)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var programFromDb = _database.StartPrograms.First(program => program.Name == tempProgram.Name);
                    if(programFromDb.Status == false)
                    {
                        programFromDb.StartDate = tempProgram.StartDate;
                        programFromDb.EndDate = tempProgram.EndDate;
                        programFromDb.Status = true;
                        _database.SaveChanges();
                        return RedirectToAction("StartPrograms", "Management");
                    }
                    else
                    {
                        return View("../Management/Error", "an active Program record with that name"); 
                    }
                }
                catch (System.Exception)
                {
                    StartProgram newProgram = new StartProgram();
                    newProgram.Id = tempProgram.Id;
                    newProgram.Name = tempProgram.Name;
                    newProgram.StartDate = tempProgram.StartDate;
                    newProgram.EndDate = tempProgram.EndDate.Date;
                    newProgram.Status = true;
                    _database.StartPrograms.Add(newProgram);
                    _database.SaveChanges();
                    return RedirectToAction("StartPrograms", "Management");
                }
            }
            return View("../Management/NewStartProgram"); 
        }

        [HttpPost]
        public IActionResult Update(StartProgramDTO tempProgram)
        {
            if(ModelState.IsValid)
            {
                var program = _database.StartPrograms.First(program => program.Id == tempProgram.Id);
                try
                {
                    var programFromDb = _database.StartPrograms.First(program => program.Name == tempProgram.Name && program.Id != tempProgram.Id);
                    if(programFromDb.Status == false)
                    {
                        programFromDb.StartDate = tempProgram.StartDate;
                        programFromDb.EndDate = tempProgram.EndDate;
                        programFromDb.Status = true;
                        program.Status = false;
                        _database.SaveChanges();
                        return RedirectToAction("StartPrograms", "Management");
                    }
                    else
                    {
                        return View("../Management/Error", "an active Start Program with the name you're trying to update to"); 
                    }
                }
                catch (System.Exception)
                {
                    program.Name = tempProgram.Name;
                    program.StartDate = tempProgram.StartDate;
                    program.EndDate = tempProgram.EndDate;
                    _database.SaveChanges();
                    return RedirectToAction("StartPrograms", "Management");
                }
                
            }
            return View("../Management/EditStartProgram");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if(id > 0)
            {
                var program = _database.StartPrograms.First(program => program.Id == id);
                program.Status = false;
                _database.SaveChanges();
            }
            return RedirectToAction("StartPrograms", "Management");
        }
    }
}