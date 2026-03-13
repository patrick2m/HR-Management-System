using HR.Application.DTOs;

namespace HR.Application.Interfaces;

public interface IEmployeeService
{
  Task<List<EmployeeDto>> GetAllAsync();
  Task<EmployeeDto?> GetByIdAsync(Guid id);
  Task<Guid> CreateAsync(CreateEmployeeDto dto);
  Task<bool> UpdateAsync(Guid id, UpdateEmployeeDto dto);
  Task<bool> DeleteAsync(Guid id);
}