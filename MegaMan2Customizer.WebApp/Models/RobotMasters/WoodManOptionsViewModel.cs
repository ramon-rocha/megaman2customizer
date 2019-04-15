using System.ComponentModel.DataAnnotations;

namespace MegaMan2Customizer.WebApp.Models
{
    public class WoodManOptionsViewModel : BaseRobotMasterOptionsViewModel
    {
        [Display(Name = "Leaf Color")]
        public string LeafColor { get; set; }

        [Display(Name = "Leaf Delay")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte LeafDelay { get; set; }

        [Display(Name = "Jump Height")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte JumpHeight { get; set; }

        [Display(Name = "Jump Distance")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte JumpDistance { get; set; }

        [Display(Name = "Projectile Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte ProjectileSpeed { get; set; }

        [Display(Name = "Falling Leaf Count")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte FallingLeafCount { get; set; }

        [Display(Name = "Falling Leaf Horz. Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte FallingLeafHorizontalSpeed { get; set; }

        [Display(Name = "Falling Leaf Vert. Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte FallingLeafVerticalSpeed { get; set; }
    }
}
