using System.ComponentModel.DataAnnotations;

namespace MegaMan2Customizer.WebApp.Models;

public class LeafShieldOptionsViewModel : BaseWeaponOptionsViewModel
{
    [Display(Name = "Projectile Speed")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte ProjectileSpeed { get; set; }

    [Display(Name = "Ammo Used")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte AmmoUsed { get; set; }

    [Display(Name = "Deploy Delay")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte DeployDelay { get; set; }
}
