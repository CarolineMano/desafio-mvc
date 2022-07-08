using System;
using System.Linq;
using System.Threading.Tasks;
using DESAFIO.MVC.Data;
using DESAFIO.MVC.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using DESAFIO.MVC.Models;

namespace DESAFIO.MVC.Controllers
{
    public class StartersController : Controller
    {
        private readonly ApplicationDbContext _database;
        private readonly IWebHostEnvironment _hostEnvironment;
        public StartersController(ApplicationDbContext database, IWebHostEnvironment hostEnvironment)
        {
            _database = database;
            _hostEnvironment = hostEnvironment;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(StarterDTO tempStarter)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var starterFromDb = _database.Starters.First(starter => starter.FourCharacters == tempStarter.FourCharacters);
                    return View("../Management/Error", "an employee with that 4-letter indentifier"); 
                }
                catch (System.Exception)
                {
                   Starter newStarter = new Starter();
                    newStarter.Id = tempStarter.Id;
                    newStarter.Name = tempStarter.Name;
                    newStarter.FourCharacters = tempStarter.FourCharacters;
                    newStarter.StartProgramId = tempStarter.StartProgramID;
                    newStarter.StartProgram = _database.StartPrograms.First(program => program.Id == tempStarter.StartProgramID);
                    newStarter.GroupId = tempStarter.GroupID;
                    newStarter.Group = _database.Groups.First(group => group.Id == tempStarter.GroupID);
                    newStarter.ImageName = UploadedFile(tempStarter);
                    newStarter.Status = true;

                    _database.Starters.Add(newStarter);
                    await _database.SaveChangesAsync();

                    return RedirectToAction("Starters", "Management");
                }
            }
            ViewBag.StartPrograms = _database.StartPrograms.Where(program => program.Status == true).ToList();
            ViewBag.Groups = _database.Groups.Where(group => group.Status == true).Include(group => group.Technology).ToList();

            return View("../Management/NewStarter");
        }
        [HttpPost]
         public IActionResult Update(StarterDTO tempStarter)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var starterFromDb = _database.Starters.First(starter => starter.FourCharacters == tempStarter.FourCharacters &&
                        starter.Id != tempStarter.Id);
                    return View("../Management/Error", "an employee with that 4-letter indentifier"); 
                }
                catch (System.Exception)
                {
                    var starter = _database.Starters.First(starter => starter.Id == tempStarter.Id);
                    starter.Name = tempStarter.Name;
                    starter.FourCharacters = tempStarter.FourCharacters;
                    starter.StartProgramId = tempStarter.StartProgramID;
                    starter.StartProgram = _database.StartPrograms.First(program => program.Id == tempStarter.StartProgramID);
                    starter.GroupId = tempStarter.GroupID;
                    starter.Group = _database.Groups.First(group => group.Id == tempStarter.GroupID);

                    if(tempStarter.Image != null)
                    {               
                        starter.ImageName = UploadedFile(tempStarter);
                    }

                    _database.SaveChanges();
                    return RedirectToAction("Starters", "Management");
                }           
            }
            ViewBag.StartPrograms = _database.StartPrograms.Where(program => program.Status == true).ToList();
            ViewBag.Groups = _database.Groups.Where(group => group.Status == true).Include(group => group.Technology).ToList();

            return View("../Management/EditStarter");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if(id > 0)
            {
                var starter = _database.Starters.First(starter => starter.Id == id);
                starter.Status = false;
                _database.SaveChanges();
            }
            return RedirectToAction("Starters", "Management");
        }
        private string UploadedFile(StarterDTO tempStarter)
        {
            string fileName = "GFT_Logo.jpg";

            if(tempStarter.Image != null)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                string extension = Path.GetExtension(tempStarter.Image.FileName);
                fileName = tempStarter.Name + "_" + DateTime.Now.ToString("yyMMddHHmmssfff") + extension;
                string filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    tempStarter.Image.CopyTo(fileStream);
                }
            }
            return fileName;
        }
    }
}