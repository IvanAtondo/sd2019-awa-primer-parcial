using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace practica01.Models
{
    public class Role
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [NotMapped]
        public List<User> Users { get; set; }

        [NotMapped]
        public List<Permission> Permissions { get; set; }
    }
}