using FluentAssertions;
using HR.Domain.Entities;

namespace HR.Tests;

public class EmployeeTests
{
    [Fact]
    public void Should_Create_Employee_with_valid_Data()
    {
        var employee = new Employee
        {
            Name = "Patrick",
            Email = "patrick@email.com",
            Salary = 5000
        };

        employee.Name.Should().Be("Patrick");
        employee.Email.Should().Contain("@");
        employee.Salary.Should().BeGreaterThan(0);
    }
}
