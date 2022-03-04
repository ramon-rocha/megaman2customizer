using System.ComponentModel.DataAnnotations;

namespace MegaMan2Customizer.WebApp.Models;

public class CrashBomberOptionsViewModel : BaseWeaponOptionsViewModel
{
    [Display(Name = "Horizontal Speed")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte HorizontalSpeed { get; set; }

    [Display(Name = "Vertical Speed")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte VerticalSpeed { get; set; }

    [Display(Name = "Ammo Used per Shot")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte AmmoUsed { get; set; }

    [Display(Name = "Detonation Delay")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte DetonationDelay { get; set; }
}
