namespace Employment.Dto;

public class GetEmployeeDto
{
    public string Name { get; set; }
    public Guid Id { get; set; }
    public Guid DepartmentId { get; set; }
    public string DepartmentName { get; set; }
}