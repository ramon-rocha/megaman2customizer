using MegaMan2Customizer.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MegaMan2Customizer.WebApp.Models
{
    public class EditorViewModel
    {
        [HiddenInput]
        [Required]
        public IFormFile RomFile { get; set; }

        [HiddenInput]
        [Required]
        public string RomFileName { get; set; } = "";

        public IEnumerable<SelectListItem> Colors { get; } =
            Color.GetAllColors().Select(color => new SelectListItem(text: color.Name, value: color.Name));

        #region StartMenuOptions
        [Display(Name = "Background Color")]
        public string StartMenuBackgroundColor { get; set; }

        [Display(Name = "Shadow Color")]
        public string StartMenuShadowColor { get; set; }

        [Display(Name = "Border Color")]
        public string StartMenuBorderColor { get; set; }
        #endregion StartMenuOptions

        #region MegaManOptions
        [Display(Name = "Starting Health")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte MegaManStartingHealth { get; set; }

        [Display(Name = "Max Health")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte MegaManMaxHealth { get; set; }

        [Display(Name = "Running Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte MegaManRunningSpeed { get; set; }

        [Display(Name = "Jump Height")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte MegaManJumpHeight { get; set; }

        #region WeaponOptions
        public IEnumerable<SelectListItem> WeaponLetterCodes { get; } =
            Text.WeaponLetterCodes.Select(code => new SelectListItem(text: code.ToString(), value: code.ToString()));

        #region MegaBusterOptions
        [Display(Name = "Letter Code")]
        public char MegaBusterLetterCode { get; set; }

        [Display(Name = "Primary Color")]
        public string MegaBusterPrimaryColor { get; set; }

        [Display(Name = "Secondary Color")]
        public string MegaBusterSecondaryColor { get; set; }

        [Display(Name = "Projectile Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte MegaBusterProjectileSpeed { get; set; }

        [Display(Name = "Max Projectiles on Screen")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte MegaBusterMaxProjectiles { get; set; }
        #endregion MegaBusterOptions

        #region AtomicFireOptions
        [Display(Name = "Name")]
        [StringLength(14, ErrorMessage = "Weapon name cannot be longer than 14 characters")]
        public string AtomicFireName { get; set; }

        [Display(Name = "Letter Code")]
        public char AtomicFireLetterCode { get; set; }

        [Display(Name = "Primary Color")]
        public string AtomicFirePrimaryColor { get; set; }

        [Display(Name = "Secondary Color")]
        public string AtomicFireSecondaryColor { get; set; }

        [Display(Name = "Level 1 Ammo Used")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte AtomicFireLevel1AmmoUsed { get; set; }

        [Display(Name = "Level 2 Charge Time")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte AtomicFireLevel2ChargeTime { get; set; }

        [Display(Name = "Level 2 Ammo Used")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte AtomicFireLevel2AmmoUsed { get; set; }

        [Display(Name = "Level 3 Charge Time")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte AtomicFireLevel3ChargeTime { get; set; }

        [Display(Name = "Level 3 Ammo Used")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte AtomicFireLevel3AmmoUsed { get; set; }

        [Display(Name = "Projectile Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte AtomicFireProjectileSpeed { get; set; }
        #endregion AtomicFireOptions

        #region AirShooterOptions
        [Display(Name = "Name")]
        [StringLength(14, ErrorMessage = "Weapon name cannot be longer than 14 characters")]
        public string AirShooterName { get; set; }

        [Display(Name = "Letter Code")]
        public char AirShooterLetterCode { get; set; }

        [Display(Name = "Primary Color")]
        public string AirShooterPrimaryColor { get; set; }

        [Display(Name = "Secondary Color")]
        public string AirShooterSecondaryColor { get; set; }

        [Display(Name = "Number of Tornadoes")]
        [Range(1, 3, ErrorMessage = "Enter a value from 1 to 3")]
        public byte AirShooterProjectileCount { get; set; }

        [Display(Name = "Tornado 1 Horizontal Speed")]
        [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
        public decimal AirShooterProjectile1HorizontalSpeed { get; set; }

        [Display(Name = "Tornado 2 Horizontal Speed")]
        [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
        public decimal AirShooterProjectile2HorizontalSpeed { get; set; }

        [Display(Name = "Tornado 3 Horizontal Speed")]
        [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
        public decimal AirShooterProjectile3HorizontalSpeed { get; set; }

        [Display(Name = "Tornado Vertical Acceleration")]
        [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
        public decimal AirShooterVerticalAcceleration { get; set; }

        [Display(Name = "Ammo Used")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte AirShooterAmmoUsed { get; set; }
        #endregion AirShooterOptions

        #region LeafShield
        [Display(Name = "Name")]
        [StringLength(14, ErrorMessage = "Weapon name cannot be longer than 14 characters")]
        public string LeafShieldName { get; set; }

        [Display(Name = "Letter Code")]
        public char LeafShieldLetterCode { get; set; }

        [Display(Name = "Primary Color")]
        public string LeafShieldPrimaryColor { get; set; }

        [Display(Name = "Secondary Color")]
        public string LeafShieldSecondaryColor { get; set; }

        [Display(Name = "Projectile Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte LeafShieldProjectileSpeed { get; set; }

        [Display(Name = "Ammo Used")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte LeafShieldAmmoUsed { get; set; }
        #endregion LeafShield

        #region BubbleLead
        [Display(Name = "Name")]
        [StringLength(14, ErrorMessage = "Weapon name cannot be longer than 14 characters")]
        public string BubbleLeadName { get; set; }

        [Display(Name = "Letter Code")]
        public char BubbleLeadLetterCode { get; set; }

        [Display(Name = "Primary Color")]
        public string BubbleLeadPrimaryColor { get; set; }

        [Display(Name = "Secondary Color")]
        public string BubbleLeadSecondaryColor { get; set; }
        #endregion BubbleLead

        #region QuickBoomerang
        [Display(Name = "Name")]
        [StringLength(28, ErrorMessage = "Weapon name cannot be longer than 28 characters")]
        public string QuickBoomerangName { get; set; }

        [Display(Name = "Letter Code")]
        public char QuickBoomerangLetterCode { get; set; }

        [Display(Name = "Primary Color")]
        public string QuickBoomerangPrimaryColor { get; set; }

        [Display(Name = "Secondary Color")]
        public string QuickBoomerangSecondaryColor { get; set; }
        #endregion QuickBoomerang

        #region TimeStopper
        [Display(Name = "Name")]
        [StringLength(14, ErrorMessage = "Weapon name cannot be longer than 14 characters")]
        public string TimeStopperName { get; set; }

        [Display(Name = "Letter Code")]
        public char TimeStopperLetterCode { get; set; }

        [Display(Name = "Primary Color")]
        public string TimeStopperPrimaryColor { get; set; }

        [Display(Name = "Secondary Color")]
        public string TimeStopperSecondaryColor { get; set; }
        #endregion TimeStopper

        #region MetalBlade
        [Display(Name = "Name")]
        [StringLength(14, ErrorMessage = "Weapon name cannot be longer than 14 characters")]
        public string MetalBladeName { get; set; }

        [Display(Name = "Letter Code")]
        public char MetalBladeLetterCode { get; set; }

        [Display(Name = "Primary Color")]
        public string MetalBladePrimaryColor { get; set; }

        [Display(Name = "Secondary Color")]
        public string MetalBladeSecondaryColor { get; set; }
        #endregion MetalBlade

        #region CrashBomber
        [Display(Name = "Name")]
        [StringLength(14, ErrorMessage = "Weapon name cannot be longer than 14 characters")]
        public string CrashBomberName { get; set; }

        [Display(Name = "Letter Code")]
        public char CrashBomberLetterCode { get; set; }

        [Display(Name = "Primary Color")]
        public string CrashBomberPrimaryColor { get; set; }

        [Display(Name = "Secondary Color")]
        public string CrashBomberSecondaryColor { get; set; }
        #endregion CrashBomber

        #endregion WeaponOptions

        #endregion MegaManOptions
    }
}
