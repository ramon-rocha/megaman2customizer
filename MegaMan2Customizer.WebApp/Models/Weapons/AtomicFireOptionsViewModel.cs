using System.ComponentModel.DataAnnotations;

namespace MegaMan2Customizer.WebApp.Models
{
    public class AtomicFireOptionsViewModel : BaseWeaponOptionsViewModel
    {
        [Display(Name = "Level 1 Ammo Used")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte Level1AmmoUsed { get; set; }

        [Display(Name = "Level 2 Charge Time")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte Level2ChargeTime { get; set; }

        [Display(Name = "Level 2 Ammo Used")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte Level2AmmoUsed { get; set; }

        [Display(Name = "Level 3 Charge Time")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte Level3ChargeTime { get; set; }

        [Display(Name = "Level 3 Ammo Used")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte Level3AmmoUsed { get; set; }

        [Display(Name = "Projectile Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte ProjectileSpeed { get; set; }
    }
}
