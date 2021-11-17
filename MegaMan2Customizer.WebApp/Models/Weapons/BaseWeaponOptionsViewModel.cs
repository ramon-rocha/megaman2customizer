using System.ComponentModel.DataAnnotations;

namespace MegaMan2Customizer.WebApp.Models
{
    /// <summary>
    /// Contains properties for options common to all weapons
    /// </summary>
    public abstract class BaseWeaponOptionsViewModel
    {
        [Display(Name = "Name")]
        [StringLength(14, ErrorMessage = "Weapon name cannot be longer than 14 characters")]
        public virtual string Name { get; set; } = "";

        [Display(Name = "Letter Code")]
        public char LetterCode { get; set; }

        [Display(Name = "Primary Color")]
        public string PrimaryColor { get; set; } = "";

        [Display(Name = "Secondary Color")]
        public string SecondaryColor { get; set; } = "";
    }
}
