using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class RequestStatus
    {
        [Key]
        public int StatusID { get; set; }
        public string StatusName { get; set; }
    }
}
