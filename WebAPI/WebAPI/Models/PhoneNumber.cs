using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class PhoneNumber
    {
        [Key]
        public int PhoneNumberID { get; set; }
        public int UserID { get; set; }
        public string? Number { get; set; }
    }
}
