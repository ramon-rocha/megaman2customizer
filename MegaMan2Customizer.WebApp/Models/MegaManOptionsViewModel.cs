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
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte RunningSpeed { get; set; }

        [Display(Name = "Jump Height")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte JumpHeight { get; set; }
    }
}
