namespace WebAPI.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}
