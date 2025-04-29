namespace EmployeeTimeTrackingAPI.Models;

public record Location
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}