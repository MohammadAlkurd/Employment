using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employment.Models;

public class Employee
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    public Guid DepartmentId { get; set; }
    [ForeignKey("DepartmentId")]
    public Department Department { get; set; }
}