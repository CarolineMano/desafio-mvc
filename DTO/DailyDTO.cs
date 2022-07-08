using System;
using System.ComponentModel.DataAnnotations;

namespace DESAFIO.MVC.DTO
{
    public class DailyDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "The start date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "The description of the tasks in progress is required")]
        [StringLength(150, ErrorMessage = "The description of the tasks in progress must have up to {1} characters")]
        [MinLength(3, ErrorMessage = "The description of the tasks in progress must be at least {1} characters long")]
        public string TasksDoing { get; set; }
        [Required(ErrorMessage = "The description of the completed tasks is required")]
        [StringLength(150, ErrorMessage = "The description of the completed tasks must have up to {1} characters")]
        [MinLength(3, ErrorMessage = "The description of the completed tasks must be at least {1} characters long")]
        public string TasksDone { get; set; }
        [Required(ErrorMessage = "The description of the impediments is required")]
        [StringLength(150, ErrorMessage = "The description of impediments must have up to {1} characters")]
        [MinLength(3, ErrorMessage = "The description of the impediments must be at least {1} characters long")]
        public string Impediments { get; set; }
        [Required(ErrorMessage = "The presence of the starter must be informed")]
        [Range(0,2, ErrorMessage = "That value is not valid")]
        public int Presence { get; set; }
        [Required]
        public int ModuleID { get; set; }
        [Required]
        public int StarterID { get; set; }
    }
}