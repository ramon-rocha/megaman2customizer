using System.ComponentModel.DataAnnotations;

namespace MegaMan2Customizer.WebApp.Models;

public abstract class BaseRobotMasterOptionsViewModel
{
    [Display(Name = "Primary Color")]
    public string PrimaryColor { get; set; } = "";

    [Display(Name = "Secondary Color")]
    public string SecondaryColor { get; set; } = "";

    [Display(Name = "Weapon on Defeat")]
    public string WeaponOnDefeat { get; set; } = "";

    [Display(Name = "Item on Defeat")]
    public string ItemOnDefeat { get; set; } = "";
}
