using EmployeeTimeTrackingAPI.Models;
using EmployeeTimeTrackingAPI.Services;

namespace EmployeeTimeTrackingAPI.Endpoints;

public static class TimeTrackingEndpoints
{
    public  static void MapTimeTrackingEndpoints(this RouteGroupBuilder group)
    {
        // TimeTracking endpoints
        group.MapPost("/timetrackings", (TimeTracking timeTracking, ITimeTrackingService service) => 
            service.AddTimeTracking(timeTracking));

        group.MapGet("/timetrackings", (string? employeeName, int? page, int? pageSize, ITimeTrackingService timeTrackingService) =>
            timeTrackingService.GetTimeTrackings(employeeName, page, pageSize));

        group.MapGet("/timetrackings/{employeeId}", (int employeeId, int? page, int? pageSize, ITimeTrackingService timeTrackingService) =>
            timeTrackingService.GetTimeTrackingsForEmployeeId(employeeId, page, pageSize));
    }
}