namespace EmployeeTimeTrackingAPI.Models;

public record Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}