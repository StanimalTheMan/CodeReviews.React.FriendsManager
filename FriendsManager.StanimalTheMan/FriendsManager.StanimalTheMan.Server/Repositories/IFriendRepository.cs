using FriendsManager.StanimalTheMan.Server.Models;

namespace FriendsManager.StanimalTheMan.Server.Repositories;

public interface IFriendRepository
{
    Task AddFriendAsync(Friend friend);

    Task<Friend> GetFriendByIdAsync(int id);

    Task<IEnumerable<Friend>> GetAllFriendsAsync();

    Task UpdateFriendAsync(Friend friend);

    Task DeleteFriendAsync(Friend friend);
}
