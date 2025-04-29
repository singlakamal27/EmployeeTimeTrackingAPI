using EmployeeTimeTrackingAPI.Models;
using EmployeeTimeTrackingAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Xunit;

namespace EmployeeTimeTrackingAPI.Tests;

public class EmployeeServiceTests
{
    [Fact]
    public void AddEmployee_ShouldIncreaseCount()
    {
        var service = new EmployeeService();
        var employee = new Employee { FirstName = "Kamal", LastName = "Singla" };
        var result = service.AddEmployee(employee);
        
        Assert.IsType<Created<Employee>>(result);
    }

    [Fact]
    public void AddEmployee_ShouldFail_BadRequest_FirstNameMissing()
    {
        var service = new EmployeeService();
        var employee = new Employee { FirstName = "", LastName = "Singla" };
        var result = service.AddEmployee(employee);
        
        Assert.IsType<BadRequest<string>>(result);
    }
}
