using System.ComponentModel.DataAnnotations;

namespace practica01.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}