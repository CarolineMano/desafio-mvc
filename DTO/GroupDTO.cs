using System.ComponentModel.DataAnnotations;

namespace DESAFIO.MVC.DTO
{
    public class GroupDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "This group must be associated with a Start Program")]
        public int TechnologyID { get; set; }
        [Required(ErrorMessage = "It's required to have a Scrum Master")]
        public string ScrumMaster { get; set; }
    }
}