using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class UserRoles
    {
        [Key]
        public int UserRolesID { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
    }
}
