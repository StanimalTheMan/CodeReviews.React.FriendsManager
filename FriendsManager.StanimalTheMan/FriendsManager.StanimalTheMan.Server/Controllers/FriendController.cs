using FriendsManager.StanimalTheMan.Server.Models;
using FriendsManager.StanimalTheMan.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace FriendsManager.StanimalTheMan.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FriendController : Controller
{
    private readonly IFriendService _friendService;

    public FriendController(IFriendService friendService)
    {
        _friendService = friendService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Friend>>> GetFriends()
    {
        try
        {
            var friends = await _friendService.GetAllFriendsAsync();
            return Ok(friends);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Friend>> GetFriendById(int id)
    {
        try
        {
            var friend = await _friendService.GetFriendByIdAsync(id);
            if (friend == null)
            {
                return NotFound();
            }

            return Ok(friend);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Friend>> AddFriend(Friend friend)
    {
        try
        {
            await _friendService.AddFriendAsync(friend);
            return CreatedAtAction(nameof(GetFriendById), new { id = friend.FriendID }, friend);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFriend(int id, Friend friend)
    {
        if (id != friend.FriendID)
        {
            return BadRequest("Friend ID mismatch");
        }

        try
        {
            await _friendService.UpdateFriendAsync(friend);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFriend(int id)
    {
        try
        {
            var friend = await _friendService.GetFriendByIdAsync(id);
            if (friend == null)
            {
                return NotFound();
            }

            await _friendService.DeleteFriendAsync(friend);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
