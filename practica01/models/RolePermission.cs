using System.ComponentModel.DataAnnotations.Schema;

namespace practica01.Models
{
    public class RolePermission
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        // EFCore requirements
        [NotMapped]
        public Role Role { get; set; }

        [NotMapped]
        public Permission Permission { get; set; }
    }
}