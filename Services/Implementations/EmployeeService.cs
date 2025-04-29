using EmployeeTimeTrackingAPI.Models;

namespace EmployeeTimeTrackingAPI.Services;

public class EmployeeService : IEmployeeService
{
    private readonly List<Employee> _employeeList = [];
    private int _nextEmployeeId = 1;

    public IQueryable<Employee> GetEmployees() => _employeeList.AsQueryable();

    public IResult GetEmployee(int id) 
    {
        var employee = GetEmployees().FirstOrDefault(e => e.Id == id);
        return employee is null ? Results.NotFound() : Results.Ok(employee);
    } 

    public IResult AddEmployee(Employee employee)
    {
        if (string.IsNullOrWhiteSpace(employee.FirstName))
                return Results.BadRequest("Employee first name is required.");

        employee.Id = _nextEmployeeId++;
        _employeeList.Add(employee);
        
        return Results.Created($"/employees/{employee.Id}", employee);
    }

    public IResult UpdateEmployee(Employee updatedEmployee)
    {
        var employee = GetEmployees().FirstOrDefault(e => e.Id == updatedEmployee.Id);
        if (employee == null) 
            return Results.NotFound();

        employee.FirstName = updatedEmployee.FirstName;
        employee.LastName = updatedEmployee.LastName;

        return Results.Ok("Updated Successfully!");
    }

    public IResult DeleteEmployee(int id)
    {
        var employee = GetEmployees().FirstOrDefault(e => e.Id == id);
        if (employee == null) 
            return Results.NotFound();

        _employeeList.Remove(employee);
        return Results.Ok("Deleted Successfully!");
    }
}