namespace EmployeeTimeTrackingAPI.Models;

public record Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}