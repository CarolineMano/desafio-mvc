using System.Collections.Generic;
using System.Linq;
using DESAFIO.MVC.Data;
using DESAFIO.MVC.Models;

namespace DESAFIO.MVC.Helpers
{
    public static class UserBasedList
    {
        public static List<string> GetScrumMasters(ApplicationDbContext database)
        {
            List<string> scrumMasters = new List<string>();
            var scrumMastersId = database.UserClaims.Where(claim => claim.ClaimValue == "scrumMaster").Select(claim => claim.UserId).ToList();

            foreach (var item in scrumMastersId)
            {
                scrumMasters.Add(database.UserClaims.First(claim => claim.UserId == item).ClaimValue);
            }

            return scrumMasters;
        }

        public static ICollection<Starter> GetStartersBasedOnRole(string user, ApplicationDbContext database)
        {
            ICollection<Starter> starters;
            var userRole = database.UserClaims.Where(claim => claim.ClaimType == "UserRole").First(claim => claim.UserId == user).ClaimValue;

            if(userRole.Equals("scrumMaster"))
            {
                var userName = database.UserClaims.Where(claim => claim.ClaimType == "FullName").First(claim => claim.UserId == user).ClaimValue;
                starters = database.Starters.Where(starter => starter.Status == true && starter.Group.ScrumMaster.Equals(userName)).ToList();
            }
            else
            {
                starters = database.Starters.Where(starter => starter.Status == true).ToList();
            }
            return starters;
        }
    }
}