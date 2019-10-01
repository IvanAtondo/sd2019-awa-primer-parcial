using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace practica01.Models
{
    public class Permission
    {
        public int Id { get; set; }
        
        [Required, MaxLength(10)]
        public string Key { get; set; }
        
        [Required, MaxLength(100)]
        public string Description { get; set; }
        
        [Required]
        public int RoleId { get; set; }

        // EFCore requirements
        [NotMapped]
        public List<Role> Roles { get; set; }
    }
}