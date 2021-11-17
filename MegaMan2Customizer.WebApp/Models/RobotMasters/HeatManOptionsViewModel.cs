using System.ComponentModel.DataAnnotations;

namespace MegaMan2Customizer.WebApp.Models
{
    public class HeatManOptionsViewModel : BaseRobotMasterOptionsViewModel
    {
        [Display(Name = "Projectile Color 1")]
        public string ProjectileColor1 { get; set; } = "";

        [Display(Name = "Projectile Color 2")]
        public string ProjectileColor2 { get; set; } = "";

        [Display(Name = "Projectile 1 Height")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte Projectile1Height { get; set; }

        [Display(Name = "Projectile 1 Distance")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte Projectile1Distance { get; set; }

        [Display(Name = "Projectile 2 Height")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte Projectile2Height { get; set; }

        [Display(Name = "Projectile 2 Distance")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte Projectile2Distance { get; set; }

        [Display(Name = "Projectile 3 Height")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte Projectile3Height { get; set; }

        [Display(Name = "Projectile 3 Distance")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte Projectile3Distance { get; set; }

        [Display(Name = "Rush Delay 1")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte RushDelay1 { get; set; }

        [Display(Name = "Rush Delay 2")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte RushDelay2 { get; set; }

        [Display(Name = "Rush Delay 3")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte RushDelay3 { get; set; }

        [Display(Name = "Rush Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte RushSpeed { get; set; }
    }
}
