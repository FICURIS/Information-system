using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class UserEnrollment
    {
        [Key]
        public int UserEnrollmentID { get; set; }
        public int UserID { get; set; }
        public int CourseID { get; set; }
        public int RequestID { get; set; }
        public DateTime EnrollDate { get; set; }
    }
}
