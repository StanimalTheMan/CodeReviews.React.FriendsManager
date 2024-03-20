using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FriendsManager.StanimalTheMan.Server.Models;

public class Friend
{
    [Key]
    public int FriendID { get; set; }

    [Required]
    public string Name { get; set; }

    [Required(ErrorMessage = "Last Contact Date is required")]
    [Display(Name = "Last Contact Date")]
    [DataType(DataType.Date)]
    public DateTime LastContactDate { get; set; }

    [Required(ErrorMessage = "Last Contact Type is required")]
    [Display(Name = "Last Contact Type")]
    public string LastContactType { get; set; } // don't want to use enums for now as user can be flexible, e.g. phone call, in person, facetime

    [Required(ErrorMessage = "Desired Contact Frequency is required")]
    [Display(Name = "Desired Contact Frequency")]
    public string DesiredContactFrequency { get; set; } // daily, weekly, monthly, annually

    public int CategoryID { get; set; }

    [ForeignKey("CategoryID")]
    public Category Category { get; set; }
}
