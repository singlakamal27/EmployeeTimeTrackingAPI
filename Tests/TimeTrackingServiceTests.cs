using EmployeeTimeTrackingAPI.Models;
using EmployeeTimeTrackingAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Xunit;

namespace EmployeeTimeTrackingAPI.Tests;

public class TimeTrackingServiceTests
{
    [Fact]
    public void CreateTimeTracking_ShouldIncreaseCount()
    {
        var employeeService = new EmployeeService();
        var employee = new Employee { FirstName = "Kamal", LastName = "Singla" };
        employeeService.AddEmployee(employee);

        var service = new TimeTrackingService(employeeService);

        var timeTracking = new TimeTracking { 

                EmployeeId = 1, 
                StartTime = DateTime.Now,
                EndTime = null,
                Location = "West",
                Category = "PartTime",
                Notes = "Half Shift"
            };
        
        var result = service.AddTimeTracking(timeTracking);
        
        Assert.IsType<Created<TimeTracking>>(result);
    }

    [Fact]
    public void CreateTimeTracking_ShouldFail_BadRequest_EmployeeNotExist()
    {
        var employeeService = new EmployeeService();

        var service = new TimeTrackingService(employeeService);

        var timeTracking = new TimeTracking { 

                EmployeeId = 1, 
                StartTime = DateTime.Now,
                EndTime = null,
                Location = "West",
                Category = "PartTime",
                Notes = "Half Shift"
            };
        
        var result = service.AddTimeTracking(timeTracking);
        
        Assert.IsType<BadRequest<string>>(result);
    }
}
