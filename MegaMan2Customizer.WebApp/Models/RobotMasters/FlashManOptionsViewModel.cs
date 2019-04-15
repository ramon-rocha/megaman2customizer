using System.ComponentModel.DataAnnotations;

namespace MegaMan2Customizer.WebApp.Models
{
    public class FlashManOptionsViewModel : BaseRobotMasterOptionsViewModel
    {
        [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
        public decimal RunSpeed { get; set; }

        [Display(Name = "Time Stopper Delay")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte TimeStopperDelay { get; set; }

        [Display(Name = "Jump Distance")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte JumpDistance { get; set; }

        [Display(Name = "Jump Height")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte JumpHeight { get; set; }

        [Display(Name = "Projectile Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte ProjectileSpeed { get; set; }

        [Display(Name = "Projectile Count")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte ProjectileCount { get; set; }
    }
}
