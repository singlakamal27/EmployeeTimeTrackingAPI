using EmployeeTimeTrackingAPI.Models;
using EmployeeTimeTrackingAPI.Services;

namespace EmployeeTimeTrackingAPI.Endpoints;

public static class EmployeeEndpoints
{
    public static void MapEmployeeEndpoints(this IEndpointRouteBuilder group)
    {
        // Employee endpoints
        group.MapPost("/employees", (Employee employee, IEmployeeService service) => service.AddEmployee(employee));

        group.MapGet("/employees", (IEmployeeService service) =>  service.GetEmployees());

        group.MapGet("/employees/{id}", (int id, IEmployeeService service) => service.GetEmployee(id));
            
        group.MapPut("/employees/{id}", (Employee employee, IEmployeeService service) => service.UpdateEmployee(employee));

        group.MapDelete("/employees/{id}", (int id, IEmployeeService service) => service.DeleteEmployee(id));
    }
}