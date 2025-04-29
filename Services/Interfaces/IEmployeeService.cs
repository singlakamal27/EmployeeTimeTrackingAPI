using EmployeeTimeTrackingAPI.Models;

namespace EmployeeTimeTrackingAPI.Services
{
    public interface IEmployeeService
    {
        IQueryable<Employee> GetEmployees();
        IResult GetEmployee(int id);
        IResult AddEmployee(Employee employee);
        IResult UpdateEmployee(Employee updatedEmployee);
        IResult DeleteEmployee(int id);
    }
}