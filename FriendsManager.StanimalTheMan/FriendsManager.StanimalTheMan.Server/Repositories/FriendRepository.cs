using FriendsManager.StanimalTheMan.Server.Data;
using FriendsManager.StanimalTheMan.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace FriendsManager.StanimalTheMan.Server.Repositories;

public class FriendRepository : IFriendRepository
{
    private readonly FriendsManagerDbContext _context;

    public FriendRepository(FriendsManagerDbContext context)
    {
        _context = context;
    }

    public async Task AddFriendAsync(Friend friend)
    {
        var category = _context.Categories.FirstOrDefault(category => category.CategoryID == friend.CategoryID);
        
        if (category != null)
        {
            await _context.Friends.AddAsync(friend);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new InvalidOperationException("Category does not exist.  Unable to associate friend to such category.");
        }
    }

    public async Task DeleteFriendAsync(Friend friend)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                _context.Friends.Remove(friend);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("Error deleting friend.", ex);
            }
        }
    }

    public async Task<IEnumerable<Friend>> GetAllFriendsAsync()
    {
        return await _context.Friends.ToListAsync();
    }

    public async Task<Friend> GetFriendByIdAsync(int id)
    {
        return await _context.Friends.FindAsync(id);
    }

    public async Task UpdateFriendAsync(Friend friend)
    {
        var category = _context.Categories.FirstOrDefault(category => category.CategoryID == friend.CategoryID);

        if (category != null)
        {
            _context.Entry(friend).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new InvalidOperationException("Invalid category. Unable to update friend.");
        }
    }
}
