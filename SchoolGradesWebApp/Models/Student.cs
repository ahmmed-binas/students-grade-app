using System.ComponentModel.DataAnnotations;

namespace SchoolGradesWebApp.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; } // This property will serve as the primary key

        public string Name { get; set; }
        public string Subject { get; set; }
        public string Grade { get; set; }

        // The Remarks property should compute a pass/fail based on the Grade
        public string Remarks
        {
            get
            {
                // Ensure the Grade can be parsed to an integer for comparison
                if (int.TryParse(Grade, out int gradeValue))
                {
                    return gradeValue >= 75 ? "PASS" : "FAIL";
                }
                return "Invalid Grade"; // Handle non-numeric grades
            }
        }
    }
}
