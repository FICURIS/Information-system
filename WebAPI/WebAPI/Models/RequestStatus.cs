using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class RequestStatus
    {
        [Key]
        public int StatusID { get; set; }
        public string StatusName { get; set; }
    }
}
