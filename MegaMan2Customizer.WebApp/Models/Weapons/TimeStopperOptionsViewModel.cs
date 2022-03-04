using System.ComponentModel.DataAnnotations;

namespace MegaMan2Customizer.WebApp.Models;

public class TimeStopperOptionsViewModel : BaseWeaponOptionsViewModel
{
    [Display(Name = "Delay Before Drain")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte DelayBeforeDrain { get; set; }

    [Display(Name = "Drain Rate Delay")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte DrainRateDelay { get; set; }
}
