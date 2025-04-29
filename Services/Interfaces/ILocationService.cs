using EmployeeTimeTrackingAPI.Models;

namespace EmployeeTimeTrackingAPI.Services
{
    public interface ILocationService
    {
        IQueryable<Location> GetLocations();
        IResult GetLocation(int id);
        IResult AddLocation(Location location);
        IResult UpdateLocation(Location updatedLocation);
        IResult DeleteLocation(int id);
    }
}