using EmployeeTimeTrackingAPI.Models;
using EmployeeTimeTrackingAPI.Services;

namespace EmployeeTimeTrackingAPI.Endpoints;

public static class LocationEndpoints
{
    public static void MapLocationEndpoints(this RouteGroupBuilder group)
    {
        // Location endpoints
        group.MapPost("/locations", (Location location, ILocationService service) => service.AddLocation(location));

        group.MapGet("/locations", (ILocationService service) => service.GetLocations());

        group.MapGet("/locations/{id}", (int id, ILocationService service) => service.GetLocation(id));
            
        group.MapPut("/locations/{id}", (Location location, ILocationService service) => service.UpdateLocation(location));

        group.MapDelete("/locations/{id}", (int id, ILocationService service) => service.DeleteLocation(id));
    }
}