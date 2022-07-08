using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DESAFIO.MVC.Models
{
    public class Group
    {
        public int Id { get; set; }
        public int TechnologyId { get; set; }
        public Technology Technology { get; set; }
        public string ScrumMaster { get; set; }
        public bool Status { get; set; }
        [NotMapped]
        public string GroupName => $"{Technology.Name} - {ScrumMaster}";
    }
}