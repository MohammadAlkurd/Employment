using Employment.Database;
using Employment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Controllers;

[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    public AppDbContext _context;
    public DepartmentController(AppDbContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var deprtments = _context.departments.ToList();
        return Ok(deprtments);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var department = _context.departments.Find(id);
        if (department == null)
        {
            return NotFound();
        }
        return Ok(department);
    }

    [HttpPost]
    public IActionResult Create([FromBody] string name)
    {
        var department = new Department()
        {
            Name = name,
        };
        try
        {
            _context.departments.Add(department);
            _context.SaveChanges();
            return Created();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute]Guid id,[FromBody] string name)
    {
        var department =  _context.departments.FirstOrDefault(p => p.Id == id);

        if (department == null)
            return NotFound();
        department.Name = name;
        _context.SaveChanges();
        return Accepted("Department Updated");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        var department =  _context.departments.Find(id);

        if (department == null)
        {
            return NotFound();
        }

        _context.departments.Remove(department);
        _context.SaveChanges();
        return Accepted("Department Deleted");
    }
}