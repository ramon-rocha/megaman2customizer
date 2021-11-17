using System.ComponentModel.DataAnnotations;

namespace MegaMan2Customizer.WebApp.Models
{
    public class MegaManOptionsViewModel
    {
        [Display(Name = "Starting Health")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte StartingHealth { get; set; }

        [Display(Name = "Max Health")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte MaxHealth { get; set; }

        [Display(Name = "Running Speed")]
        [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
        [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
        public decimal RunningSpeed { get; set; }

        [Display(Name = "Jump Height")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte JumpHeight { get; set; }

        [Display(Name = "Jump Horizontal Speed")]
        [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
        [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
        public decimal JumpHorizontalSpeed { get; set; }

        [Display(Name = "Buster Letter Code")]
        public char BusterLetterCode { get; set; }

        [Display(Name = "Primary Color")]
        public string BusterPrimaryColor { get; set; } = "";

        [Display(Name = "Secondary Color")]
        public string BusterSecondaryColor { get; set; } = "";

        [Display(Name = "Projectile Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte BusterProjectileSpeed { get; set; }

        [Display(Name = "Max Projectiles on Screen")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte BusterMaxProjectiles { get; set; }
    }
}
