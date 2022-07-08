using System.ComponentModel.DataAnnotations;

namespace DESAFIO.MVC.DTO
{
    public class TechnologyDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "The name of the technology is required")]
        [StringLength(15, ErrorMessage = "The name of the technology must have up to {1} characters")]
        public string Name { get; set; }
        [StringLength(150, ErrorMessage = "The description must have up to {1} characters")]
        public string Description { get; set; }
    }
}