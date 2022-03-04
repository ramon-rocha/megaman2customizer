using System.ComponentModel.DataAnnotations;

namespace MegaMan2Customizer.WebApp.Models;

public class AirShooterOptionsViewModel : BaseWeaponOptionsViewModel
{
    [Display(Name = "Number of Tornadoes")]
    [Range(1, 3, ErrorMessage = "Enter a value from 1 to 3")]
    public byte ProjectileCount { get; set; }

    [Display(Name = "Tornado 1 Horiz. Speed")]
    [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
    [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
    public decimal Projectile1HorizontalSpeed { get; set; }

    [Display(Name = "Tornado 2 Horiz. Speed")]
    [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
    [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
    public decimal Projectile2HorizontalSpeed { get; set; }

    [Display(Name = "Tornado 3 Horiz. Speed")]
    [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
    [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
    public decimal Projectile3HorizontalSpeed { get; set; }

    [Display(Name = "Tornado Vert. Acceleration")]
    [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
    [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
    public decimal VerticalAcceleration { get; set; }

    [Display(Name = "Ammo Used")]
    [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
    public byte AmmoUsed { get; set; }
}
