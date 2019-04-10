using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using MegaMan2Customizer.Core;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace MegaMan2Customizer.WebApp.Models
{
    /// <summary>
    /// Contains options for all weapons
    /// </summary>
    public class AllWeaponOptionsViewModel
    {
        public static IEnumerable<SelectListItem> WeaponLetterCodes { get; } =
            Text.WeaponLetterCodes.Select(code => new SelectListItem(text: code.ToString(), value: code.ToString()));

        #region BusterOptions
        [Display(Name = "Letter Code")]
        public char BusterLetterCode { get; set; }

        [Display(Name = "Primary Color")]
        public string BusterPrimaryColor { get; set; }

        [Display(Name = "Secondary Color")]
        public string BusterSecondaryColor { get; set; }

        [Display(Name = "Projectile Speed")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte BusterProjectileSpeed { get; set; }

        [Display(Name = "Max Projectiles on Screen")]
        [Range(0, 255, ErrorMessage = "Enter a value from 0 to 255")]
        public byte BusterMaxProjectiles { get; set; }
        #endregion BusterOptions

        public AtomicFireOptionsViewModel AtomicFire { get; set; } = new AtomicFireOptionsViewModel();

        public AirShooterOptionsViewModel AirShooter { get; set; } = new AirShooterOptionsViewModel();

        public LeafShieldOptionsViewModel LeafShield { get; set; } = new LeafShieldOptionsViewModel();

        public BubbleLeadOptionsViewModel BubbleLead { get; set; } = new BubbleLeadOptionsViewModel();

        public QuickBoomerangOptionsViewModel QuickBoomerang { get; set; } = new QuickBoomerangOptionsViewModel();

        public TimeStopperOptionsViewModel TimeStopper { get; set; } = new TimeStopperOptionsViewModel();

        public MetalBladeOptionsViewModel MetalBlade { get; set; } = new MetalBladeOptionsViewModel();

        public CrashBomberOptionsViewModel CrashBomber { get; set; } = new CrashBomberOptionsViewModel();

    }
}
