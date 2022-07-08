using System;

namespace DESAFIO.MVC.Models
{
    public class Daily
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string TasksDoing { get; set; }
        public string TasksDone { get; set; }
        public string Impediments { get; set; }
        public int Presence { get; set; }
        public bool Status { get; set; }
        public int ModuleId { get; set; }
        public Module Module { get; set; }
        public int StarterId { get; set; }
        public Starter Starter { get; set; }
    }
}