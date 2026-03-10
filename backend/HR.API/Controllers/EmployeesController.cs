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
  public async Task<List<Employee>> Get()
  {
    return await _context.Employees.ToListAsync();
  }

  [HttpPost]
  public async Task<IActionResult> Create(Employee employee)
  {
    _context.Employees.Add(employee);
    await _context.SaveChangesAsync();
    
    return Ok(employee);    
  }
}