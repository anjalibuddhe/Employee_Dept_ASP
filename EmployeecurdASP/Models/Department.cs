using System.ComponentModel.DataAnnotations;

namespace EmployeecurdASP.Models
{
    public class Department
    {
        [Key]
        
        public int DId { get; set; }
        [Required]
        public string? Dname { get; set; }
    }
}
