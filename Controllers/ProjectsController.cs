using System.Data;
using System.IO;
using System.Linq;
using ClosedXML.Excel;
using DESAFIO.MVC.Data;
using DESAFIO.MVC.DTO;
using DESAFIO.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DESAFIO.MVC.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _database;
        public ProjectsController(ApplicationDbContext database)
        {
            _database = database;
        }
        [HttpPost]
        public IActionResult Save(ProjectDTO tempProject)
        {
            if(ModelState.IsValid)
            {
                Project newProject = new Project();
                newProject.Id = tempProject.Id;
                newProject.ModuleId = tempProject.ModuleID;
                newProject.Module = _database.Modules.First(module => module.Id == tempProject.ModuleID);
                newProject.StarterId = tempProject.StarterID;
                newProject.Starter = _database.Starters.First(starter => starter.Id == tempProject.StarterID);
                newProject.Grade = tempProject.Grade;
                newProject.Status = true;

                _database.Projects.Add(newProject);
                _database.SaveChanges();

                return RedirectToAction("Projects", "Management");
            }
            ViewBag.Starters = _database.Starters.Where(starter => starter.Status == true).ToList();
            ViewBag.Modules = _database.Modules.Where(module => module.Status == true).ToList();  
            return View("../Management/NewProject");
        }
        [HttpPost]
        public IActionResult Update(ProjectDTO tempProject)
        {   
            if(ModelState.IsValid)
            {
                var project = _database.Projects.First(project => project.Id == tempProject.Id);
                project.ModuleId = tempProject.ModuleID;
                project.Module = _database.Modules.First(module => module.Id == tempProject.ModuleID);
                project.StarterId = tempProject.StarterID;
                project.Starter = _database.Starters.First(starter => starter.Id == tempProject.StarterID);
                project.Grade = tempProject.Grade;
                _database.SaveChanges();

                return RedirectToAction("Projects", "Management");
            }
            ViewBag.Starters = _database.Starters.Where(starter => starter.Status == true).ToList();
            ViewBag.Modules = _database.Modules.Where(module => module.Status == true).ToList();  
            return View("../Management/EditProject");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if(id > 0)
            {
                var project = _database.Projects.First(project => project.Id == id);
                project.Status = false;
                _database.SaveChanges();
            }
            return RedirectToAction("Projects", "Management");
        }
        [HttpPost]
        public IActionResult Export()
        {
            DataTable datatable = new DataTable("Grades");
            datatable.Columns.AddRange(new DataColumn[4] {
                new DataColumn("ProjectId"),
                new DataColumn("StarterName"),
                new DataColumn("Module"),
                new DataColumn("Grade")
            });

            var projects = _database.Projects.Where(project => project.Status == true).Include(project => project.Starter).Include(project => project.Module).ToList();
            projects = projects.OrderBy(project => project.Grade).ToList();

            foreach(var project in projects)
            {
                datatable.Rows.Add(project.Id, project.Starter.Name, project.Module.Name, project.Grade);
            }

            using (XLWorkbook workbook = new XLWorkbook())
            {
                 workbook.Worksheets.Add(datatable);
                 using (MemoryStream stream = new MemoryStream())
                 {
                    workbook.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grades.xlsx");
                 }
            }
        }
    }
}