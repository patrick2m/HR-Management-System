using HR.Application.DTOs;
using HR.Application.Interfaces;
using HR.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
  private readonly IEmployeeService _service;

  public EmployeesController(IEmployeeService service)
  {
    _service = service;
  }

  [HttpGet]
  public async Task<IActionResult> Get()
    => Ok(await _service.GetAllAsync());

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(Guid id)
  {
    var employee = await _service.GetByIdAsync(id);

    if (employee == null)
      return NotFound();

    return Ok(employee);
  }

  [HttpPost]
  public async Task<IActionResult> Create(CreateEmployeeDto dto)
  {
    var id = await _service.CreateAsync(dto);
    return CreatedAtAction(nameof(GetById), new { id = id }, dto);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(Guid id, UpdateEmployeeDto dto)
  {
    var updated = await _service.UpdateAsync(id, dto);

    if (!updated)
      return NotFound();
    
    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(Guid id)
  {
    var deleted = await _service.DeleteAsync(id);

    if (!deleted)
      return NotFound();

    return NoContent();
  }
}