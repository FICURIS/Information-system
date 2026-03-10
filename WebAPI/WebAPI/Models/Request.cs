namespace WebAPI.Models
{
    public class Request
    {
        public int RequestID { get; set; }
        public int UserID { get; set; }
        public int CourseID { get; set; }
        public int StatusID { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
