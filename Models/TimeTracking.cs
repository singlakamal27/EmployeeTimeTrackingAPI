namespace EmployeeTimeTrackingAPI.Models;

public record TimeTracking
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime?  StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string Location { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
}