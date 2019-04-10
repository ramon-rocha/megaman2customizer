using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using MegaMan2Customizer.Core;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public static IEnumerable<SelectListItem> Colors { get; } =
            Color.GetAllColors().Select(color => new SelectListItem(text: color.Name, value: color.Name));

        public static IEnumerable<SelectListItem> WeaponListItems { get; } = new SelectListItem[]
        {
            new SelectListItem("None", "0")
        };

        public static IEnumerable<SelectListItem> Items { get; } = new SelectListItem[]
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

        public MegaManOptionsViewModel MegaMan { get; set; }

        public AllWeaponOptionsViewModel Weapons { get; set; } = new AllWeaponOptionsViewModel();

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
