using System.ComponentModel.DataAnnotations;

namespace Employment.Models;

public class Department
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
}