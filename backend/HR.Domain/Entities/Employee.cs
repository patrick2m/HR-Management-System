namespace HR.Domain.Entities;

public class Employee
{
  public Guid Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Position { get; set; } = string.Empty;
  public decimal Salary { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}