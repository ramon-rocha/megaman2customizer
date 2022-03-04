using System.ComponentModel.DataAnnotations;

namespace MegaMan2Customizer.WebApp.Models;

public class BubbleLeadOptionsViewModel : BaseWeaponOptionsViewModel
{
    [Display(Name = "Max Projectiles on Screen")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte MaxProjectiles { get; set; }

    [Display(Name = "Shots per Ammo Tick")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte ShotsPerAmmo { get; set; }

    [Display(Name = "Horizontal Speed")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte HorizontalSpeed { get; set; }

    [Display(Name = "Vertical Speed")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte VerticalSpeed { get; set; }

    [Display(Name = "Surface Speed")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte SurfaceSpeed { get; set; }

    [Display(Name = "Horizontal Falling Speed")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte HorizontalFallingSpeed { get; set; }

    [Display(Name = "Vertical Falling Speed")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte VerticalFallingSpeed { get; set; }
}
