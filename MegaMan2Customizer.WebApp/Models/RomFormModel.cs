using MegaMan2Customizer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaMan2Customizer.WebApp.Models
{
    public class RomFormModel
    {
        /// <summary>
        /// FileName of ROM uploaded by user
        /// </summary>
        public string RomFileName { get; set; }

        public MegaMan2Rom Rom { get; set; }
    }
}
