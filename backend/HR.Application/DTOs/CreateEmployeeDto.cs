namespace HR.Application.DTOs;

public class CreateEmployeeDto
{
  public string Name { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Position { get; set; } = string.Empty;
  public decimal Salary { get; set; }
}