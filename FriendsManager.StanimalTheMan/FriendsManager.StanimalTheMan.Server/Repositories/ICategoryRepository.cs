using FriendsManager.StanimalTheMan.Server.Models;

namespace FriendsManager.StanimalTheMan.Server.Repositories;

public interface ICategoryRepository
{
    Task AddCategoryAsync(Category category);
    Task<Category> GetCategoryByIdAsync(int id);
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task UpdateCategoryAsync(Category category);
    Task DeleteCategoryAndFriendsAsync(Category category);
}
