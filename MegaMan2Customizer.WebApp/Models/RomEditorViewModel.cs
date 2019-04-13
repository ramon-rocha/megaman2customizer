using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        #region StartMenuOptions
        [Display(Name = "Background Color")]
        public string StartMenuBackgroundColor { get; set; }

        [Display(Name = "Shadow Color")]
        public string StartMenuShadowColor { get; set; }

        [Display(Name = "Border Color")]
        public string StartMenuBorderColor { get; set; }
        #endregion StartMenuOptions

        public MegaManOptionsViewModel MegaMan { get; set; }

        public WeaponUpgradeOptionsViewModel Weapons { get; set; } = new WeaponUpgradeOptionsViewModel();

        public AllRobotMasterOptionsViewModel RobotMasters { get; set; } = new AllRobotMasterOptionsViewModel();
    }
}
