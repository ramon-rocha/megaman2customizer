using System.ComponentModel.DataAnnotations;

namespace MegaMan2Customizer.WebApp.Models
{
    public class MetalManOptionsViewModel : BaseRobotMasterOptionsViewModel
    {
        [Display(Name = "Blade Color")]
        public string BladeColor { get; set; } = "";

        [Display(Name = "Projectile Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte ProjectileSpeed { get; set; }

        [Display(Name = "Jump 1 Height")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte Jump1Height { get; set; }

        [Display(Name = "Jump 2 Height")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte Jump2Height { get; set; }

        [Display(Name = "Jump 3 Height")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte Jump3Height { get; set; }
    }
}
