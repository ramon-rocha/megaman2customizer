using System;
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

        public static IEnumerable<SelectListItem> WeaponListItems { get; } =
            ((WeaponId[])Enum.GetValues(typeof(WeaponId)))
                .Select(id => new SelectListItem(
                    text: id.ToDisplayString(),
                    value: id.ToString()
                ));

        public static IEnumerable<SelectListItem> Items { get; } =
            ((ItemId[])Enum.GetValues(typeof(ItemId)))
                .Select(id => new SelectListItem(
                    text: id.ToDisplayString(),
                    value: id.ToString()
                ));
    }
}
