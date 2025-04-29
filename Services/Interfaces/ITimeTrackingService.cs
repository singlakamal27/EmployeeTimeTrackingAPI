using EmployeeTimeTrackingAPI.Models;

namespace EmployeeTimeTrackingAPI.Services
{
    public interface ITimeTrackingService
    {
        IResult GetTimeTrackings(string? employeeName, int? page, int? pageSize);
        IResult GetTimeTrackingsForEmployeeId(int employeeId, int? page, int? pageSize);
        IResult AddTimeTracking(TimeTracking timeTracking);
    }
}