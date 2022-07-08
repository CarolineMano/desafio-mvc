namespace DESAFIO.MVC.Models
{
    public class Project
    {
        public int Id { get; set; }
        public int StarterId { get; set; }
        public Starter Starter { get; set; }
        public float Grade { get; set; }
        public int ModuleId { get; set; }
        public Module Module { get; set; }
        public bool Status { get; set; }
    }
}