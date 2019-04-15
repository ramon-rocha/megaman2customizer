using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MegaMan2Customizer.WebApp.Models
{
    public class TornadoOptionsViewModel
    {
        [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
        public decimal VerticalVelocity { get; set; }

        [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
        public decimal HorizontalVelocity { get; set; }

        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte FlightTime { get; set; }
    }

    public class TornadoPatternViewModel
    {
        public List<TornadoOptionsViewModel> Tornados { get; set; }
    }
    public class AirManOptionsViewModel : BaseRobotMasterOptionsViewModel
    {
        [Display(Name = "Tornado Primary Color")]
        public string TornadoPrimaryColor { get; set; }

        [Display(Name = "Tornado Secondary Color")]
        public string TornadoSecondaryColor { get; set; }

        [Display(Name = "Shots Before Jumping")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte ShotsBeforeJumping { get; set; }

        [Display(Name = "First Jump Distance")]
        [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
        public decimal Jump1Distance { get; set; }

        [Display(Name = "First Jump Height")]
        [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
        public decimal Jump1Height { get; set; }

        [Display(Name = "Second Jump Distance")]
        [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
        public decimal Jump2Distance { get; set; }

        [Display(Name = "Second Jump Height")]
        [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
        public decimal Jump2Height { get; set; }

        public List<TornadoPatternViewModel> TornadoPatterns { get; set; }
    }
}