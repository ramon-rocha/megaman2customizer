using System.ComponentModel.DataAnnotations;

namespace MegaMan2Customizer.WebApp.Models
{
    public class MetalBladeOptionsViewModel : BaseWeaponOptionsViewModel
    {
        [Display(Name = "Max Projectiles on Screen")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte MaxShots { get; set; }

        [Display(Name = "Shots per Ammo Tick")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte ShotsPerAmmo { get; set; }

        [Display(Name = "Projectile Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte ProjectileSpeed { get; set; }
    }
}
