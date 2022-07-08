using System;
using System.ComponentModel.DataAnnotations;

namespace DESAFIO.MVC.DTO
{
    public class StartProgramDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "The name of the program must have up to {1} characters")]
        [MinLength(5, ErrorMessage = "The name must be at least {1} characters long")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The start date is required")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "The end date is required")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}