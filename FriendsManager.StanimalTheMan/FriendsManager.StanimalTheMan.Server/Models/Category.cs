using System.ComponentModel.DataAnnotations;

namespace FriendsManager.StanimalTheMan.Server.Models;

public class Category
{
    public int CategoryID { get; set; }

    [Required(ErrorMessage = "Category name is required")]
    public string Name { get; set; }

    public virtual ICollection<Friend> Friends { get; set; }
}
