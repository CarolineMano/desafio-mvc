using System.ComponentModel.DataAnnotations;

namespace DESAFIO.MVC.DTO
{
    public class ProjectDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "The project must be associated with a Starter")]
        public int StarterID { get; set; }
        [Required(ErrorMessage = "The project must be graded")]
        [Range(0, 10, ErrorMessage = "The grade must be between {1} and {2}. You can also try to change the decimal separator")]
        public float Grade { get; set; }
        [Required(ErrorMessage = "The project must be associated with a module")]
        public int ModuleID { get; set; }
    }
}