using System.Runtime.Serialization;
using HR.Application.DTOs;
using HR.Application.Interfaces;
using HR.Domain.Entities;
using HR.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HR.Application.Services;

public class EmployeeService : IEmployeeService
{
  private readonly AppDbContext _context;

  public EmployeeService(AppDbContext context)
  {
    _context = context;
  }

  public async Task<List<EmployeeDto>> GetAllAsync()
  {
    return await _context.Employees
      .Select(e => new EmployeeDto
      {
        Id = e.Id,
        Name = e.Name,
        Email = e.Email,
        Position = e.Position,
        Salary = e.Salary,
        CreatedAt = e.CreatedAt
      })
      .ToListAsync();
  }

  public async Task<EmployeeDto?> GetByIdAsync(Guid id)
  {
    var employee = await _context.Employees.FindAsync(id);
    if (employee == null) return null;

    return new EmployeeDto
    {
      Id = employee.Id,
      Name = employee.Name,
      Email = employee.Email,
      Position = employee.Position,
      Salary = employee.Salary,
      CreatedAt = employee.CreatedAt
    };
  }

  public async Task<Guid> CreateAsync(CreateEmployeeDto dto)
  {
    var employee = new Employee
    {
      Id = Guid.NewGuid(),
      Name = dto.Name,
      Email = dto.Email,
      Position = dto.Position,
      Salary = dto.Salary,
      CreatedAt = DateTime.UtcNow
    };

    _context.Employees.Add(employee);

    await _context.SaveChangesAsync();

    return employee.Id;
  }

  public async Task<bool> UpdateAsync(Guid id, UpdateEmployeeDto dto)
  {
    var employee = await _context.Employees.FindAsync(id);

    if (employee == null)
      return false;

    employee.Name = dto.Name;
    employee.Email = dto.Email;
    employee.Position = dto.Position;
    employee.Salary = dto.Salary;

    await _context.SaveChangesAsync();

    return true;
  }

  public async Task<bool> DeleteAsync(Guid id)
  {
    var employee = await _context.Employees.FindAsync(id);

    if (employee == null)
      return false;
    
    _context.Employees.Remove(employee);

    await _context.SaveChangesAsync();

    return true;
  }
}