using EmployeeTimeTrackingAPI.Models;
using EmployeeTimeTrackingAPI.Services;

namespace EmployeeTimeTrackingAPI.Endpoints;

public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints(this RouteGroupBuilder group)
    {
        // Category endpoints
        group.MapPost("/categories", (Category category, ICategoryService service) => service.AddCategory(category));

        group.MapGet("/categories", (ICategoryService service) => service.GetCategories());

        group.MapGet("/categories/{id}", (int id, ICategoryService service) => service.GetCategory(id));
            
        group.MapPut("/categories/{id}", (Category category, ICategoryService service) => service.UpdateCategory(category));

        group.MapDelete("/categories/{id}", (int id, ICategoryService service) => service.DeleteCategory(id));
    }
}