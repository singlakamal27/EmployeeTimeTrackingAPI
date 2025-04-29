using EmployeeTimeTrackingAPI.Models;

namespace EmployeeTimeTrackingAPI.Services
{
    public interface ICategoryService
    {
        IQueryable<Category> GetCategories();
        IResult GetCategory(int id);
        IResult AddCategory(Category category);
        IResult UpdateCategory(Category updatedCategory);
        IResult DeleteCategory(int id);
    }
}