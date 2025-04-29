using EmployeeTimeTrackingAPI.Models;

namespace EmployeeTimeTrackingAPI.Services;

public class CategoryService : ICategoryService
{
    private readonly List<Category> _categoryList = [];
    private int _nextCategoryId = 1;

    public IQueryable<Category> GetCategories() => _categoryList.AsQueryable();

    public IResult GetCategory(int id) {
        
       var category = GetCategories().FirstOrDefault(c => c.Id == id);
       return category is null ? Results.NotFound() : Results.Ok(category);
    }

    public IResult AddCategory(Category category)
    {
        if (string.IsNullOrWhiteSpace(category.Name))
                return Results.BadRequest("Category name is missing.");

        category.Id = _nextCategoryId++;
        _categoryList.Add(category);
        
        return Results.Created($"/categories/{category.Id}", category);
    }

    public IResult UpdateCategory(Category updatedCategory)
    {
        var category = GetCategories().FirstOrDefault(c => c.Id == updatedCategory.Id);
        if (category == null) 
            return Results.NotFound();

        category.Name = updatedCategory.Name;
        return Results.Ok("Updated Successfully!");
    }

    public IResult DeleteCategory(int id)
    {
        var category = GetCategories().FirstOrDefault(c => c.Id == id);
        if (category == null) 
            return Results.NotFound();

        _categoryList.Remove(category);
        return Results.Ok("Deleted Successfully!");
    }
}