using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using DESAFIO.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DESAFIO.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<StartProgram> StartPrograms {get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Starter> Starters { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Daily> Dailies { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

         protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedUsers(builder);
            this.SeedData(builder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            IdentityUser user1 = new IdentityUser()
            {
                Id = "849bb501-93c9-4b32-a86a-265f5d27a1be",
                UserName = "clecio.silva@gft.com",
                Email = "clecio.silva@gft.com",
                NormalizedEmail = "CLECIO.SILVA@GFT.COM",
                NormalizedUserName = "CLECIO.SILVA@GFT.COM",
                EmailConfirmed = true,
                LockoutEnabled = true,
                PasswordHash = hasher.HashPassword(null, "Gft2021")
            };

            IdentityUser user2 = new IdentityUser()
            {
                Id = "6eef2868-d9db-47a0-b23f-f512cf387390",
                UserName = "zezinho@gft.com",
                Email = "zezinho@gft.com",
                NormalizedEmail = "ZEZINHO@GFT.COM",
                NormalizedUserName = "ZEZINHO@GFT.COM",
                EmailConfirmed = true,
                LockoutEnabled = true,
                PasswordHash = hasher.HashPassword(null, "Scrum2021")
            };

            IdentityUser user3 = new IdentityUser()
            {
                Id = "b21c526c-5931-4e6c-bac9-d6e8977034cf",
                UserName = "luisinho@gft.com",
                Email = "luisinho@gft.com",
                NormalizedEmail = "LUISINHO@GFT.COM",
                NormalizedUserName = "LUISINHO@GFT.COM",
                EmailConfirmed = true,
                LockoutEnabled = true,
                PasswordHash = hasher.HashPassword(null, "Scrum2021")
            };

            IdentityUser user4 = new IdentityUser()
            {
                Id = "7a615f2c-dddc-4741-bc95-bf70ed616355",
                UserName = "huguinho@gft.com",
                Email = "huguinho@gft.com",
                NormalizedEmail = "HUGUINHO@GFT.COM",
                NormalizedUserName = "HUGUINHO@GFT.COM",
                EmailConfirmed = true,
                LockoutEnabled = true,
                PasswordHash = hasher.HashPassword(null, "Scrum2021")
            };

            builder.Entity<IdentityUser>().HasData(user1);
            builder.Entity<IdentityUser>().HasData(user2);
            builder.Entity<IdentityUser>().HasData(user3);
            builder.Entity<IdentityUser>().HasData(user4);   
        
            IdentityUserClaim<string> user1FullName = new IdentityUserClaim<string>()
            {
                Id = 1,
                UserId = "849bb501-93c9-4b32-a86a-265f5d27a1be",
                ClaimType = "FullName",
                ClaimValue = "Clécio Silva"
            };

            IdentityUserClaim<string> user1Role = new IdentityUserClaim<string>()
            {
                Id = 2,
                UserId = "849bb501-93c9-4b32-a86a-265f5d27a1be",
                ClaimType = "UserRole",
                ClaimValue = "admin"
            };

            IdentityUserClaim<string> user2FullName = new IdentityUserClaim<string>()
            {
                Id = 3,
                UserId = "6eef2868-d9db-47a0-b23f-f512cf387390",
                ClaimType = "FullName",
                ClaimValue = "Zezinho"
            };

            IdentityUserClaim<string> user2Role = new IdentityUserClaim<string>()
            {
                Id = 4,
                UserId = "6eef2868-d9db-47a0-b23f-f512cf387390",
                ClaimType = "UserRole",
                ClaimValue = "scrumMaster"
            };

            IdentityUserClaim<string> user3FullName = new IdentityUserClaim<string>()
            {
                Id = 5,
                UserId = "b21c526c-5931-4e6c-bac9-d6e8977034cf",
                ClaimType = "FullName",
                ClaimValue = "Luisinho"
            };

            IdentityUserClaim<string> user3Role = new IdentityUserClaim<string>()
            {
                Id = 6,
                UserId = "b21c526c-5931-4e6c-bac9-d6e8977034cf",
                ClaimType = "UserRole",
                ClaimValue = "scrumMaster"
            };

            IdentityUserClaim<string> user4FullName = new IdentityUserClaim<string>()
            {
                Id = 7,
                UserId = "7a615f2c-dddc-4741-bc95-bf70ed616355",
                ClaimType = "FullName",
                ClaimValue = "Huguinho"
            };

            IdentityUserClaim<string> user4Role = new IdentityUserClaim<string>()
            {
                Id = 8,
                UserId = "7a615f2c-dddc-4741-bc95-bf70ed616355",
                ClaimType = "UserRole",
                ClaimValue = "scrumMaster"
            };

            builder.Entity<IdentityUserClaim<string>>().HasData(user1FullName);
            builder.Entity<IdentityUserClaim<string>>().HasData(user1Role);
            builder.Entity<IdentityUserClaim<string>>().HasData(user2FullName);
            builder.Entity<IdentityUserClaim<string>>().HasData(user2Role);
            builder.Entity<IdentityUserClaim<string>>().HasData(user3FullName);
            builder.Entity<IdentityUserClaim<string>>().HasData(user3Role);
            builder.Entity<IdentityUserClaim<string>>().HasData(user4FullName);
            builder.Entity<IdentityUserClaim<string>>().HasData(user4Role);
        }

        private void SeedData(ModelBuilder builder)
        {
            StartProgram program1 = new StartProgram()
            {
                Id = 1,
                Name = "Turma 1",
                StartDate = DateTime.Parse("2021-03-01 00:00:00.000000"),
                EndDate = DateTime.Parse("2021-06-01 00:00:00.000000"),
                Status = true
            };

            StartProgram program2 = new StartProgram()
            {
                Id = 2,
                Name = "Turma 2",
                StartDate = DateTime.Parse("2021-05-02 00:00:00.000000"),
                EndDate = DateTime.Parse("2021-08-02 00:00:00.000000"),
                Status = true
            };

            builder.Entity<StartProgram>().HasData(program1);
            builder.Entity<StartProgram>().HasData(program2);

            Technology tech1 = new Technology()
            {
                Id = 1,
                Name = ".NET",
                Description = ".NET with C# and Visual Studio Code",
                Status = true
            };

            Technology tech2 = new Technology()
            {
                Id = 2,
                Name = "Java",
                Description = "No description available",
                Status = true
            };

            builder.Entity<Technology>().HasData(tech1);
            builder.Entity<Technology>().HasData(tech2);

            Group group1 = new Group()
            {
                Id = 1,
                TechnologyId = 1,
                ScrumMaster = "Luisinho",
                Status = true
            };

            Group group2 = new Group()
            {
                Id = 2,
                TechnologyId = 2,
                ScrumMaster = "Luisinho",
                Status = true
            };

            builder.Entity<Group>().HasData(group1);
            builder.Entity<Group>().HasData(group2);

            Starter starter1 = new Starter()
            {
                Id = 1,
                Name = "Pucca",
                FourCharacters = "PAMM",
                StartProgramId = 1,
                GroupId = 1,
                ImageName = "IMG_20201112_130915.jpg",
                Status = true
            };

            Starter starter2 = new Starter()
            {
                Id = 2,
                Name = "Mochi",
                FourCharacters = "MIMM",
                StartProgramId = 1,
                GroupId = 2,
                ImageName = "IMG_20211116_162601.jpg",
                Status = true
            };

            builder.Entity<Starter>().HasData(starter1);
            builder.Entity<Starter>().HasData(starter2);

            Module module1 = new Module()
            {
                Id = 1,
                Name = "MVC",
                Status = true
            };

            Module module2 = new Module()
            {
                Id = 2,
                Name = "API",
                Status = true
            };

            builder.Entity<Module>().HasData(module1);
            builder.Entity<Module>().HasData(module2);

            Project project1 = new Project()
            {
                Id = 1,
                ModuleId = 1,
                StarterId = 1,
                Grade = 10,
                Status = true
            };

            Project project2 = new Project()
            {
                Id = 2,
                ModuleId = 1,
                StarterId = 2,
                Grade = 9,
                Status = true
            };

            builder.Entity<Project>().HasData(project1);
            builder.Entity<Project>().HasData(project2);

            Daily daily1 = new Daily()
            {
                Id = 1,
                Date = DateTime.Now,
                TasksDoing = "Authentication",
                TasksDone = "CRUD",
                Impediments = "None",
                Presence = 2,
                ModuleId = 1,
                StarterId = 1,
                Status = true
            };
            
            Daily daily2 = new Daily()
            {
                Id = 2,
                Date = DateTime.Now,
                TasksDoing = "Data seed",
                TasksDone = "Authentication",
                Impediments = "None",
                Presence = 2,
                ModuleId = 1,
                StarterId = 2,
                Status = true
            };

            builder.Entity<Daily>().HasData(daily1);
            builder.Entity<Daily>().HasData(daily2);
        }

    }
}
