using FriendsManager.StanimalTheMan.Server.Models;

namespace FriendsManager.StanimalTheMan.Server.Services;

public interface IFriendService
{
    Task AddFriendAsync(Friend friend);

    Task DeleteFriendAsync(Friend friend);
    Task<IEnumerable<Friend>> GetAllFriendsAsync();
    Task<Friend> GetFriendByIdAsync(int id);
    Task UpdateFriendAsync(Friend friend);
}
