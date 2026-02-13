using Employment.Database;
using Employment.Dto;
using Employment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employment.Controllers;

[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    public AppDbContext _context;
    
    public EmployeeController(AppDbContext context)
    {
        this._context = context;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        var employees = _context.employees.Include(p=>p.Department).Select(p => new GetEmployeeDto()
        {
            Id = p.Id,
            Name = p.Name,
            DepartmentId = p.DepartmentId,
            DepartmentName = p.Department.Name,
        }).ToList();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var employee = _context.employees.Include(p => p.Department).Where(p => p.Id == id)
            .Select(p => new GetEmployeeDto()
            {
                Id = p.Id,
                Name = p.Name,
                DepartmentId = p.DepartmentId,
                DepartmentName = p.Department.Name,
            }).First();
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpPost]
    public IActionResult Create([FromBody] AddEmployeeDto dto)
    {
        var dep =  _context.departments.Find(dto.DepartmentId);
        if (dep == null)
        {
            return NotFound("department not found");
        }
        var employee = new Employee()
        {
            Name = dto.Name,
            DepartmentId = dto.DepartmentId,
            Department = dep
        };
        try
        {
            _context.employees.Add(employee);
            _context.SaveChanges();
            return Created();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute]Guid id,AddEmployeeDto dto)
    {
        var dep =  _context.departments.Find(dto.DepartmentId);
        if (dep == null)
        {
            return NotFound("department not found");
        }
        var employee = _context.employees.Find(id);
        if (employee == null)
        {
            return NotFound("employee not found");
        }
        try
        {
            employee.Name = dto.Name;
            employee.DepartmentId = dto.DepartmentId;
            employee.Department = dep;
            _context.SaveChanges();
            return Accepted("updated employee");
        }
        catch (Exception e)
        {
            return BadRequest();
        }

    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        var employee =  _context.employees.Find(id);

        if (employee == null)
        {
            return NotFound();
        }

        _context.employees.Remove(employee);
        _context.SaveChanges();
        return Accepted("employee deleted");
    }
}