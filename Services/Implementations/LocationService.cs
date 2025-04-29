using EmployeeTimeTrackingAPI.Models;

namespace EmployeeTimeTrackingAPI.Services;

public class LocationService : ILocationService
{
    private readonly List<Location> _locationList = [];
    private int _nextLocationId = 1;

    public IQueryable<Location> GetLocations() => _locationList.AsQueryable();

    public IResult GetLocation(int id) 
    {
        var location = GetLocations().FirstOrDefault(loc => loc.Id == id);
        return location is null ? Results.NotFound() : Results.Ok(location);
    } 

    public IResult AddLocation(Location location)
    {
        if (string.IsNullOrWhiteSpace(location.Name))
                return Results.BadRequest("Location name is missing.");

        location.Id = _nextLocationId++;
        _locationList.Add(location);
        
        return Results.Created($"/locations/{location.Id}", location);
    }

    public IResult UpdateLocation(Location updatedLocation)
    {
        var location = GetLocations().FirstOrDefault(loc => loc.Id == updatedLocation.Id);
        if (location == null) 
            return Results.NotFound();

        location.Name = updatedLocation.Name;
        return Results.Ok("Updated Successfully!");
    }

    public IResult DeleteLocation(int id)
    {
        var location = GetLocations().FirstOrDefault(loc => loc.Id == id);
        if (location == null) 
            return Results.NotFound();

        _locationList.Remove(location);
        return Results.Ok("Deleted Successfully!");
    }
}