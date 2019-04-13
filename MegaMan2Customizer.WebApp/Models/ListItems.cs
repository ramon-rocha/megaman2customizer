using System.Collections.Generic;
using System.Linq;

using MegaMan2Customizer.Core;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace MegaMan2Customizer.WebApp.Models
{
    public static class ListItems
    {
        public static IEnumerable<SelectListItem> Colors { get; } =
            Color.GetAllColors().Select(color => new SelectListItem(text: color.Name, value: color.Name));

        public static IEnumerable<SelectListItem> WeaponLetterCodes { get; } =
            Text.WeaponLetterCodes.Select(code => new SelectListItem(text: code.ToString(), value: code.ToString()));

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
    }
}
