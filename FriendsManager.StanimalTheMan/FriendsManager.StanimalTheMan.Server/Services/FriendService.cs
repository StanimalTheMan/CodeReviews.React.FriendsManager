using FriendsManager.StanimalTheMan.Server.Models;
using FriendsManager.StanimalTheMan.Server.Repositories;

namespace FriendsManager.StanimalTheMan.Server.Services;

public class FriendService : IFriendService
{
    private readonly IFriendRepository _friendRepository;

    public FriendService(IFriendRepository friendRepository)
    {
        _friendRepository = friendRepository;
    }

    public async Task AddFriendAsync(Friend friend)
    {
        await _friendRepository.AddFriendAsync(friend);
    }

    public async Task DeleteFriendAsync(Friend friend)
    {
        await _friendRepository.DeleteFriendAsync(friend);
    }

    public async Task<IEnumerable<Friend>> GetAllFriendsAsync()
    {
        return await _friendRepository.GetAllFriendsAsync();
    }

    public async Task<Friend> GetFriendByIdAsync(int id)
    {
        return await _friendRepository.GetFriendByIdAsync(id);
    }

    public async Task UpdateFriendAsync(Friend friend)
    {
        await _friendRepository.UpdateFriendAsync(friend);
    }
}


