using HR.Domain.Entities;
using HR.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR.API.Controllers;

[ApiController]
[Route("employees")]
public class EmployeesController : ControllerBase
{
  private readonly AppDbContext _context;

  public EmployeesController(AppDbContext context)
  {
    _context = context;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var employees = await _context.Employees.ToListAsync();
    return Ok(employees);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id)
  {
    var employee = await _context.Employees.FindAsync(id);

    if (employee == null)
      return NotFound();

    return Ok(employee);
  }

  [HttpPost]
  public async Task<IActionResult> Create(Employee employee)
  {
    _context.Employees.Add(employee);
    await _context.SaveChangesAsync();
    
    return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(Guid id, Employee updated)
  {
    var employee = await _context.Employees.FindAsync(id);

    if (employee == null)
      return NotFound();
    
    employee.Name = updated.Name;
    employee.Email = updated.Email;
    employee.Salary = updated.Salary;

    await _context.SaveChangesAsync();

    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(Guid id)
  {
    var employee = await _context.Employees.FindAsync(id);

    if (employee == null)
      return NotFound();
    
    _context.Employees.Remove(employee);
    await _context.SaveChangesAsync();

    return NoContent();
  }
}