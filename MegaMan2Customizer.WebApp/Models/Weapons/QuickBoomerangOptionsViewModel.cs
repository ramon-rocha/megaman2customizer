using System.ComponentModel.DataAnnotations;

namespace MegaMan2Customizer.WebApp.Models
{
    public class QuickBoomerangOptionsViewModel : BaseWeaponOptionsViewModel
    {
        [StringLength(28, ErrorMessage = "Weapon name cannot be longer than 28 characters")]
        public override string Name { get; set; } = "";

        [Display(Name = "Fire Delay")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte FireDelay { get; set; }

        [Display(Name = "Max Projectiles on Screen")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte MaxShots { get; set; }

        [Display(Name = "Shots per Ammo Tick")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte ShotsPerAmmo { get; set; }

        [Display(Name = "Travel Distance")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte TravelDistance { get; set; }

        [Display(Name = "Launch Angle")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte LaunchAngle { get; set; }

        [Display(Name = "Return Angle")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte ReturnAngle { get; set; }

        [Display(Name = "Flight Time")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte Time { get; set; }
    }
}
