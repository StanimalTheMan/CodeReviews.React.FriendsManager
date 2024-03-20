using FriendsManager.StanimalTheMan.Server.Models;

namespace FriendsManager.StanimalTheMan.Server.Services;

public interface ICategoryService
{
    Task AddCategoryAsync(Category category);
    Task DeleteCategoryAndFriendsAsync(Category category);
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int id);
    Task UpdateCategoryAsync(Category category);
}
