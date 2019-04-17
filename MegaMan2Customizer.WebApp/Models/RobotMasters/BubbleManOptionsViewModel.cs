using System.ComponentModel.DataAnnotations;

namespace MegaMan2Customizer.WebApp.Models
{
    public class BubbleManOptionsViewModel : BaseRobotMasterOptionsViewModel
    {
        [Display(Name = "Rise Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte RiseSpeed { get; set; }

        [Display(Name = "Max Height")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte MaxHeight { get; set; }

        [Display(Name = "Fall Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte FallSpeed { get; set; }

        [Display(Name = "Shot Delay")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte ShotDelay { get; set; }

        [Display(Name = "Projectile Speed")]
        [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
        [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
        public decimal ProjectileSpeed { get; set; }

        [Display(Name = "Bubble Launch Speed")]
        [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
        [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
        public decimal BubbleLaunchSpeed { get; set; }

        [Display(Name = "Bubble Bounce Speed")]
        [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
        [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
        public decimal BubbleBounceSpeed { get; set; }
    }
}
