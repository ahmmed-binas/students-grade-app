using System.ComponentModel.DataAnnotations;

namespace SchoolGradesWebApp.Models
{
    public class Subject
    {
        [Key]
        public int SubjectKey { get; set; } 
        public string SubjectName { get; set; } 
    }
}
