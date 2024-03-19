using FriendsManager.StanimalTheMan.Server.Data;
using FriendsManager.StanimalTheMan.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace FriendsManager.StanimalTheMan.Server.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly FriendsManagerDbContext _context;

    public CategoryRepository(FriendsManagerDbContext context)
    {
        _context = context;
    }

    public async Task AddCategoryAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCategoryAndFriendsAsync(Category category)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                _context.Friends.RemoveRange(category.Friends);
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Error deleting category and friends.", ex);
            }
        }
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        _context.Entry(category).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
