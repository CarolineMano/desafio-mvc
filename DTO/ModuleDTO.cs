using System.ComponentModel.DataAnnotations;

namespace DESAFIO.MVC.DTO
{
    public class ModuleDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "The module name is required")]
        [StringLength(15, ErrorMessage = "The module name must be up to {1} characters long")]
        [MinLength(2, ErrorMessage = "The module name must be at least {1} characters long")]
        public string Name { get; set; }
    }
}