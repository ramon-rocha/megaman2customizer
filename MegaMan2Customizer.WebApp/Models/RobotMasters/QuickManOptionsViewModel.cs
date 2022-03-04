using System.ComponentModel.DataAnnotations;

namespace MegaMan2Customizer.WebApp.Models;

public class QuickManOptionsViewModel : BaseRobotMasterOptionsViewModel
{
    [Display(Name = "Boomerang Count")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte ProjectileCount { get; set; }

    [Display(Name = "Boomerang Return Delay")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte ProjectileReturnDelay { get; set; }

    [Display(Name = "Boomerang Launch Speed")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte ProjectileLaunchSpeed { get; set; }

    [Display(Name = "Boomerang Return Speed")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte ProjectileReturnSpeed { get; set; }

    [Display(Name = "Jump 1 Height")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte Jump1Height { get; set; }

    [Display(Name = "Jump 2 Height")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte Jump2Height { get; set; }

    [Display(Name = "Jump 3 Height")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte Jump3Height { get; set; }

    [Display(Name = "Run Speed")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte RunSpeed { get; set; }

    [Display(Name = "Run Duration")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte RunDuration { get; set; }
}
