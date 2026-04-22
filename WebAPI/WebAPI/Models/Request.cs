using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Request
    {
        [Key]
        public int RequestID { get; set; }
        public int UserID { get; set; }
        public User? User { get; set; }
        public int CourseID { get; set; }
        public Course? Course { get; set; }
        public int StatusID { get; set; }
        public RequestStatus? Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
