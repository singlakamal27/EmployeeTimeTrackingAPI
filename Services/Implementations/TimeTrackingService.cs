using System.Linq;
using EmployeeTimeTrackingAPI.Models;

namespace EmployeeTimeTrackingAPI.Services;

public class TimeTrackingService: ITimeTrackingService
{
    private readonly IEmployeeService _employeeService;
    private readonly List<TimeTracking> _timeTrackingList = [];
    private int _nextTimeTrackingId = 1;

    public TimeTrackingService(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public IResult GetTimeTrackings(string? employeeName, int? page, int? pageSize) 
    {
        List<int> employeeIds;

        if(!string.IsNullOrWhiteSpace(employeeName))
            employeeIds = _employeeService.GetEmployees().Where(e => e.FirstName.Contains(employeeName, StringComparison.OrdinalIgnoreCase) 
                                            || e.LastName.Contains(employeeName, StringComparison.OrdinalIgnoreCase))
                                            .Select(e => e.Id).ToList();
        else
            employeeIds = _employeeService.GetEmployees().Select(e => e.Id).ToList();

        var groupedTimeTrackings = _timeTrackingList.Where(t =>  employeeIds.Contains(t.EmployeeId))
            .OrderByDescending(t => t.Id)
            .AsQueryable();

        if (page.HasValue && pageSize.HasValue)
            groupedTimeTrackings = groupedTimeTrackings.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);

        return Results.Ok(groupedTimeTrackings);
    }

    public IResult GetTimeTrackingsForEmployeeId(int employeeId, int? page, int? pageSize) 
    {
        Employee? employee = _employeeService.GetEmployees().FirstOrDefault(e => e.Id == employeeId);
        if (employee == null)
            return Results.NotFound("Employee doesn't Exists!");

        var groupedTimeTrackings = _timeTrackingList.Where(t =>  employeeId == t.EmployeeId)
            .OrderByDescending(t => t.Id)
            .AsQueryable();

        if (page.HasValue && pageSize.HasValue)
            groupedTimeTrackings = groupedTimeTrackings.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);

        return Results.Ok(groupedTimeTrackings);
    }

    public IResult AddTimeTracking(TimeTracking timeTracking)
    {
        if(!timeTracking.StartTime.HasValue && !timeTracking.EndTime.HasValue)
                return Results.BadRequest("Both time tracking start and end time are missing. One must be set!");

        if(timeTracking.StartTime.HasValue && timeTracking.EndTime.HasValue 
            && timeTracking.StartTime >= timeTracking.EndTime)
                return Results.BadRequest("Starttime must be less than endtime");

        Employee? employee = _employeeService.GetEmployees().FirstOrDefault(e => e.Id == timeTracking.EmployeeId);
        if (employee == null)
            return Results.BadRequest("Employee doesn't exist.");

        timeTracking.Id = _nextTimeTrackingId++;
        _timeTrackingList.Add(timeTracking);
        return Results.Created($"/timetracking/{timeTracking.Id}", timeTracking);
    }
}