using System.ComponentModel.DataAnnotations;

namespace MegaMan2Customizer.WebApp.Models;

public class CrashManOptionsViewModel : BaseRobotMasterOptionsViewModel
{
    [Display(Name = "Walk Speed")]
    [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
    [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
    public decimal WalkSpeed { get; set; }

    [Display(Name = "Jump Height")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte JumpHeight { get; set; }

    [Display(Name = "Projectile Speed")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte ProjectileSpeed { get; set; }
}
