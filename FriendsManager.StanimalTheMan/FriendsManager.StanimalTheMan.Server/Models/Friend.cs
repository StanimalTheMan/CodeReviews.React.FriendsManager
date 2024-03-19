using System.ComponentModel.DataAnnotations.Schema;

namespace FriendsManager.StanimalTheMan.Server.Models;

public class Friend
{
    public int FriendID { get; set; }
    public string Name { get; set; }
    public DateTime LastContactDate { get; set; }
    public string LastContactType { get; set; } // don't want to use enums for now as user can be flexible, e.g. phone call, in person, facetime
    public string DesiredContactFrequency { get; set; } // daily, weekly, monthly, annually

    public int CategoryID { get; set; }

    [ForeignKey("CategoryID")]
    public Category Category { get; set; }
}
