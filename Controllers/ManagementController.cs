using System;
using System.Linq;
using DESAFIO.MVC.Data;
using DESAFIO.MVC.DTO;
using DESAFIO.MVC.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DESAFIO.MVC.Controllers
{
    public class ManagementController : Controller
    {
        private readonly ApplicationDbContext _database;
        private readonly UserManager<IdentityUser> _userManager;
        public ManagementController(ApplicationDbContext database, UserManager<IdentityUser> userManager)
        {
            _database = database;
            _userManager = userManager;
        }
        [Authorize(Policy = "Admin")]
        public IActionResult Technologies()
        {
            var technologies = _database.Technologies.Where(technology => technology.Status == true).ToList();
            return View(technologies);
        }
        [Authorize(Policy = "Admin")]
        public IActionResult NewTechnology()
        {
            return View();
        }
        [Authorize(Policy = "Admin")]
        public IActionResult EditTechnology(int id)
        {
            TechnologyDTO technologyView = new TechnologyDTO();
            var technology = _database.Technologies.First(technology => technology.Id == id);
            technologyView.Id = technology.Id;
            technologyView.Name = technology.Name;
            technologyView.Description = technology.Description;
            return View(technologyView);
        }
        [Authorize(Policy = "Admin")]
        public IActionResult StartPrograms()
        {
            var programs = _database.StartPrograms.Where(program => program.Status == true).ToList();
            return View(programs);
        }
        [Authorize(Policy = "Admin")]
        public IActionResult NewStartProgram()
        {
            return View();
        }
        [Authorize(Policy = "Admin")]
        public IActionResult EditStartProgram(int id)
        {
            StartProgramDTO programView = new StartProgramDTO();
            var program = _database.StartPrograms.First(program => program.Id == id);
            programView.Id = program.Id;
            programView.Name = program.Name;
            programView.StartDate = program.StartDate;
            programView.EndDate = program.EndDate;
            return View(programView);
        }
        [Authorize(Policy = "Admin")]
        public IActionResult Groups()
        {
            var groups = _database.Groups.Where(group => group.Status == true).Include(group => group.Technology).ToList();
            return View(groups);
        }
        [Authorize(Policy = "Admin")]
        public IActionResult NewGroup()
        {
            ViewBag.StartPrograms = _database.StartPrograms.Where(program => program.Status == true).ToList();
            ViewBag.Technologies = _database.Technologies.Where(technology => technology.Status == true).ToList();
            ViewBag.ScrumMasters = UserBasedList.GetScrumMasters(_database);

            return View();
        }
        [Authorize(Policy = "Admin")]
        public IActionResult EditGroup(int id)
        {
            GroupDTO groupView = new GroupDTO();
            var group = _database.Groups.Include(group => group.Technology).First(group => group.Id == id);
            groupView.Id = group.Id;
            groupView.TechnologyID = group.Technology.Id;
            groupView.ScrumMaster = group.ScrumMaster;

            ViewBag.StartPrograms = _database.StartPrograms.Where(program => program.Status == true).ToList();
            ViewBag.Technologies = _database.Technologies.Where(technology => technology.Status == true).ToList();
            ViewBag.ScrumMasters = UserBasedList.GetScrumMasters(_database);

            return View(groupView);
        }
        [Authorize(Policy = "Admin")]
        public IActionResult Modules()
        {
            var modules = _database.Modules.Where(module => module.Status == true).ToList();
            return View(modules);
        }
        [Authorize(Policy = "Admin")]
        public IActionResult NewModule()
        {
            return View();
        }
        [Authorize(Policy = "Admin")]
        public IActionResult EditModule(int id)
        {
            ModuleDTO moduleView = new ModuleDTO();
            var module = _database.Modules.First(module => module.Id == id);
            moduleView.Id = module.Id;
            moduleView.Name = module.Name;
            return View(moduleView);
        }
        [Authorize(Policy = "Admin")]
        public IActionResult Starters()
        {
            var starters = _database.Starters.Where(starter => starter.Status == true).Include(starter => starter.StartProgram).
                Include(starter => starter.Group).Include(starter => starter.Group.Technology).ToList();
            return View(starters);
        }
        [Authorize(Policy = "Admin")]
        public IActionResult NewStarter()
        {
            ViewBag.StartPrograms = _database.StartPrograms.Where(program => program.Status == true).ToList();
            ViewBag.Groups = _database.Groups.Where(group => group.Status == true).Include(group => group.Technology).ToList();
                       
            return View();
        }

        [Authorize(Policy = "Admin")]
        public IActionResult EditStarter(int id)
        {
            StarterDTO starterView = new StarterDTO();
            var starter = _database.Starters.Include(starter => starter.StartProgram).Include(starter => starter.Group).First(starter => starter.Id == id);
            starterView.Id = starter.Id;
            starterView.Name = starter.Name;
            starterView.FourCharacters = starter.FourCharacters;
            starterView.StartProgramID = starter.StartProgram.Id;
            starterView.GroupID = starter.Group.Id;

            ViewBag.StartPrograms = _database.StartPrograms.Where(program => program.Status == true).ToList();
            ViewBag.Groups = _database.Groups.Where(group => group.Status == true).Include(group => group.Technology).ToList();

            return View(starterView);
        }
        [Authorize(Policy = "Admin")]
        public IActionResult Projects()
        {
            var projects = _database.Projects.Where(project => project.Status == true).Include(project => project.Starter).
                Include(project => project.Module).ToList();
            return View(projects);
        }
        [Authorize(Policy = "Admin")]
        public IActionResult NewProject()
        {
            ViewBag.Starters = _database.Starters.Where(starter => starter.Status == true).ToList();
            ViewBag.Modules = _database.Modules.Where(module => module.Status == true).ToList();        
            return View();
        }
        [Authorize(Policy = "Admin")]
        public IActionResult EditProject(int id)
        {
            ProjectDTO projectView = new ProjectDTO();
            var project = _database.Projects.Include(project => project.Starter).Include(project => project.Module).First(project => project.Id == id);
            projectView.Id = project.Id;
            projectView.ModuleID = project.Module.Id;
            projectView.StarterID = project.Starter.Id;
            projectView.Grade = project.Grade;

            ViewBag.Starters = _database.Starters.Where(starter => starter.Status == true).ToList();
            ViewBag.Modules = _database.Modules.Where(module => module.Status == true).ToList(); 

            return View(projectView);
        }
        [Authorize]
        public IActionResult Dailies()
        {
            var dailies = _database.Dailies.Where(daily => daily.Status == true).Include(daily => daily.Starter).Include(daily => daily.Module).
                Include(daily => daily.Starter.Group).Include(daily => daily.Starter.Group.Technology).ToList();

            var user = _userManager.GetUserId(User);
            var userRole = _database.UserClaims.Where(claim => claim.ClaimType == "UserRole").First(claim => claim.UserId == user).ClaimValue;

            if(userRole.Equals("scrumMaster"))
            {
                var userName = _database.UserClaims.Where(claim => claim.ClaimType == "FullName").First(claim => claim.UserId == user).ClaimValue;
                dailies = _database.Dailies.Where(daily => daily.Status == true && daily.Starter.Group.ScrumMaster.Equals(userName)).Include(daily => daily.Starter).
                    Include(daily => daily.Module).Include(daily => daily.Starter.Group).Include(daily => daily.Starter.Group.Technology).ToList();
            } 

            return View(dailies);
        }
        [Authorize]
        public IActionResult NewDaily()
        {
            DailyDTO tempDaily = new DailyDTO();
            tempDaily.Date = System.DateTime.Today;

            ViewBag.Modules = _database.Modules.Where(module => module.Status == true).ToList();
            ViewBag.Starters = UserBasedList.GetStartersBasedOnRole(_userManager.GetUserId(User), _database);
            return View(tempDaily);
        }
        [Authorize]
        public IActionResult EditDaily(int id)
        {
            DailyDTO dailyView = new DailyDTO();
            var daily = _database.Dailies.Include(daily => daily.Starter).Include(daily => daily.Module).First(daily => daily.Id == id);
            dailyView.Id = daily.Id;
            dailyView.StarterID = daily.Starter.Id;
            dailyView.ModuleID = daily.Module.Id;
            dailyView.TasksDoing = daily.TasksDoing;
            dailyView.TasksDone = daily.TasksDone;
            dailyView.Impediments = daily.Impediments;
            dailyView.Date= daily.Date;
            dailyView.Presence = daily.Presence;

            ViewBag.Modules = _database.Modules.Where(module => module.Status == true).ToList();
            ViewBag.Starters = UserBasedList.GetStartersBasedOnRole(_userManager.GetUserId(User), _database);

            return View(dailyView);
        }
    }
}