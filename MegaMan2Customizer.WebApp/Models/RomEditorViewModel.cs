using MegaMan2Customizer.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MegaMan2Customizer.WebApp.Models
{
    public class RomEditorViewModel
    {
        [HiddenInput]
        [Required]
        public IFormFile RomFile { get; set; }

        [HiddenInput]
        [Required]
        public string RomFileName { get; set; } = "";

        public IEnumerable<SelectListItem> Colors { get; } =
            Color.GetAllColors().Select(color => new SelectListItem(text: color.Name, value: color.Name));

        public IEnumerable<SelectListItem> Weapons { get; } = new SelectListItem[]
        {
            new SelectListItem("None", "0")
        };

        public IEnumerable<SelectListItem> Items { get; } = new SelectListItem[]
        {
            new SelectListItem("None", "0"),
            new SelectListItem("Item-1", "1"),
            new SelectListItem("Item-2", "2"),
            new SelectListItem("Item-3", "3")
        };

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

        [Display(Name = "Tornado 1 Horiz. Speed")]
        [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
        public decimal AirShooterProjectile1HorizontalSpeed { get; set; }

        [Display(Name = "Tornado 2 Horiz. Speed")]
        [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
        public decimal AirShooterProjectile2HorizontalSpeed { get; set; }

        [Display(Name = "Tornado 3 Horiz. Speed")]
        [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
        public decimal AirShooterProjectile3HorizontalSpeed { get; set; }

        [Display(Name = "Tornado Vert. Acceleration")]
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

        [Display(Name = "Deploy Delay")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte LeafShieldDeployDelay { get; set; }
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

        [Display(Name = "Max Projectiles on Screen")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte BubbleLeadMaxProjectiles { get; set; }

        [Display(Name = "Shots per Ammo Tick")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte BubbleLeadShotsPerAmmo { get; set; }

        [Display(Name = "Horizontal Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte BubbleLeadHorizontalSpeed { get; set; }

        [Display(Name = "Vertical Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte BubbleLeadVerticalSpeed { get; set; }

        [Display(Name = "Surface Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte BubbleLeadSurfaceSpeed { get; set; }

        [Display(Name = "Horizontal Falling Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte BubbleLeadHorizontalFallingSpeed { get; set; }

        [Display(Name = "Vertical Falling Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte BubbleLeadVerticalFallingSpeed { get; set; }
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

        [Display(Name = "Fire Delay")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte QuickBoomerangFireDelay { get; set; }

        [Display(Name = "Max Projectiles on Screen")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte QuickBoomerangMaxShots { get; set; }

        [Display(Name = "Shots per Ammo Tick")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte QuickBoomerangShotsPerAmmo { get; set; }

        [Display(Name = "Travel Distance")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte QuickBoomerangTravelDistance { get; set; }

        [Display(Name = "Launch Angle")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte QuickBoomerangLaunchAngle { get; set; }

        [Display(Name = "Return Angle")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte QuickBoomerangReturnAngle { get; set; }

        [Display(Name = "Flight Time")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte QuickBoomerangTime { get; set; }
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

        [Display(Name = "Delay Before Drain")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte TimeStopperDelayBeforeDrain { get; set; }

        [Display(Name = "Drain Rate Delay")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte TimeStopperDrainRateDelay { get; set; }
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

        [Display(Name = "Max Projectiles on Screen")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte MetalBladeMaxShots { get; set; }

        [Display(Name = "Shots per Ammo Tick")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte MetalBladeShotsPerAmmo { get; set; }

        [Display(Name = "Projectile Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte MetalBladeProjectileSpeed { get; set; }
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

        [Display(Name = "Horizontal Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte CrashBomberHorizontalSpeed { get; set; }

        [Display(Name = "Vertical Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte CrashBomberVerticalSpeed { get; set; }

        [Display(Name = "Ammo Used per Shot")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte CrashBomberAmmoUsed { get; set; }

        [Display(Name = "Detonation Delay")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte CrashBomberDetonationDelay { get; set; }
        #endregion CrashBomber

        #endregion WeaponOptions

        #endregion MegaManOptions

        #region RobotMasters

        #region BubbleMan
        [Display(Name = "Primary Color")]
        public string BubbleManPrimaryColor { get; set; }

        [Display(Name = "Secondary Color")]
        public string BubbleManSecondaryColor { get; set; }

        [Display(Name = "Weapon on Defeat")]
        public string BubbleManWeaponOnDefeat { get; set; }

        [Display(Name = "Item on Defeat")]
        public string BubbleManItemOnDefeat { get; set; }

        [Display(Name = "Rise Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte BubbleManRiseSpeed { get; set; }

        [Display(Name = "Max Height")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte BubbleManMaxHeight { get; set; }

        [Display(Name = "Fall Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte BubblemanFallSpeed { get; set; }

        [Display(Name = "Shot Delay")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte BubblemanShotDelay { get; set; }

        [Display(Name = "Projectile Speed")]
        [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
        public decimal BubblemanProjectileSpeed { get; set; }

        [Display(Name = "Bubble Launch Speed")]
        [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
        public decimal BubblemanBubbleLaunchSpeed { get; set; }

        [Display(Name = "Bubble Bounce Speed")]
        [Range(0, 255.99609375, ErrorMessage = "Enter a value from 0 to 255.99609375")]
        public decimal BubbleManBubbleBounceSpeed { get; set; }
        #endregion BubbleMan

        #region AirMan
        [Display(Name = "Primary Color")]
        public string AirManPrimaryColor { get; set; }

        [Display(Name = "Secondary Color")]
        public string AirManSecondaryColor { get; set; }
        #endregion AirMan

        #region QuickMan
        [Display(Name = "Primary Color")]
        public string QuickManPrimaryColor { get; set; }

        [Display(Name = "Secondary Color")]
        public string QuickManSecondaryColor { get; set; }
        #endregion QuickMan

        #region HeatMan
        [Display(Name = "Primary Color")]
        public string HeatManPrimaryColor { get; set; }

        [Display(Name = "Secondary Color")]
        public string HeatManSecondaryColor { get; set; }
        #endregion HeatMan

        #region WoodMan
        [Display(Name = "Primary Color")]
        public string WoodManPrimaryColor { get; set; }

        [Display(Name = "Secondary Color")]
        public string WoodManSecondaryColor { get; set; }
        #endregion WoodMan

        #region MetalMan
        [Display(Name = "Primary Color")]
        public string MetalManPrimaryColor { get; set; }

        [Display(Name = "Secondary Color")]
        public string MetalManSecondaryColor { get; set; }
        #endregion MetalMan

        #region FlashMan
        [Display(Name = "Primary Color")]
        public string FlashManPrimaryColor { get; set; }

        [Display(Name = "Secondary Color")]
        public string FlashManSecondaryColor { get; set; }
        #endregion FlashMan

        #region CrashMan
        [Display(Name = "Primary Color")]
        public string CrashManPrimaryColor { get; set; }

        [Display(Name = "Secondary Color")]
        public string CrashManSecondaryColor { get; set; }
        #endregion CrashMan

        #endregion RobotMasters
    }
}
