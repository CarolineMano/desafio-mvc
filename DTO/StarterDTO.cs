using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace DESAFIO.MVC.DTO
{
    public class StarterDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The name must have up to {1} characters")]
        [MinLength(3, ErrorMessage = "The name must be at least {1} characters long")]
        public string Name { get; set; }
        [Required]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "The identifier must be {1} characters long")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "The identifier must contain only letters")]
        public string FourCharacters { get; set; }
        [Required(ErrorMessage = "The Starter must be associated with a Starter Program")]
        public int StartProgramID { get; set; }
        [Required(ErrorMessage = "This Starter must be associated with a Scrum Group")]
        public int GroupID { get; set; }
        public IFormFile Image { get; set; }
    }
}