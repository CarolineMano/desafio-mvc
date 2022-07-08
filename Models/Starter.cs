using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace DESAFIO.MVC.Models
{
    public class Starter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FourCharacters { get; set; }
        public int StartProgramId { get; set; }
        public StartProgram StartProgram { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public bool Status { get; set; }
        public string ImageName { get; set; }
    }
}