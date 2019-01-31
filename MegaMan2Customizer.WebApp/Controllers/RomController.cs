using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using MegaMan2Customizer.Core;
using MegaMan2Customizer.WebApp.Models;

namespace MegaMan2Customizer.WebApp.Controllers
{
    public class RomController : Controller
    {
        [HttpGet("editor")]
        public IActionResult Editor(RomFormModel model)
        {
            if (model == null)
            {
                return View("Editor");
            }

            return View("Editor", model);
        }

        [HttpPost("romdata")]
        public async Task<IActionResult> RomData(IFormFile romFile, string romFileName)
        {

            string path = Path.GetTempFileName();
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await romFile.CopyToAsync(stream);
                }
                var rom = new MegaManRom(path);

                var model = new RomFormModel
                {
                    RomFileName = romFileName,
                    Rom = rom
                };
                return PartialView("_RomData", model);
            }
            finally
            {
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
        }

        [HttpPost("rom")]
        public async Task<IActionResult> CreateCustomRom(IFormFile romFile, string romFileName, 
            byte startingHealth, byte maxHealth, byte speed, byte jumpHeight, string busterPrimaryColor, string busterSecondaryColor, byte busterSpeed, byte busterShots,
            string atomicFirePrimaryColor, string atomicFireSecondaryColor, byte atomicFireLevel1Ammo, byte atomicFireLevel2ChargeTime, byte atomicFireLevel2Ammo, byte atomicFireLevel3ChargeTime, byte atomicFireLevel3Ammo, byte atomicFireSpeed,
            string airShooterPrimaryColor, string airShooterSecondaryColor, byte airShooterAmmo, byte airShooterShots,
            string bubbleManPrimaryColor, string bubbleManSecondaryColor,
            string airManPrimaryColor, string airManSecondaryColor, byte airManShotsBeforeJumping, decimal airManJump1Distance, decimal airManJump2Distance, decimal airManJump1Height, decimal airManJump2Height, decimal[] airManTornadoVertSpeed, decimal[] airManTornadoHorzSpeed, int[] airManTornadoFlightTime,
            string quickManPrimaryColor, string quickManSecondaryColor, byte quickManRunSpeed, byte quickManRunDuration, byte quickManProjectileCount, byte quickManProjectileLaunchSpeed, byte quickManProjectileReturnDelay, byte quickManProjectileReturnSpeed,
            string heatManPrimaryColor, string heatManSecondaryColor,
            string woodManPrimaryColor, string woodManSecondaryColor,
            string metalManPrimaryColor, string metalManSecondaryColor,
            string flashManPrimaryColor, string flashManSecondaryColor, decimal flashManSpeed, byte flashManTimeStopperDelay, byte flashManJumpDistance, byte flashManJumpHeight, byte flashManProjectileCount, byte flashManProjectileSpeed,
            string crashManPrimaryColor, string crashManSecondaryColor
            )
        {
            if (airManTornadoVertSpeed.Length != airManTornadoHorzSpeed.Length
                || airManTornadoVertSpeed.Length != airManTornadoFlightTime.Length)
            {
                return BadRequest($"Mismatch in number of elements for {nameof(airManTornadoVertSpeed)}, {nameof(airManTornadoHorzSpeed)}, and {nameof(airManTornadoFlightTime)}");
            }

            string path = Path.GetTempFileName();
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await romFile.CopyToAsync(stream);
                }
                var rom = new MegaManRom(path);

                MegaManOptions megaMan = rom.MegaManOptions;
                megaMan.StartingHealth = startingHealth;
                megaMan.MaxHealth = maxHealth;
                megaMan.Speed = speed;
                megaMan.JumpHeight = jumpHeight;
                megaMan.BusterPrimaryColor = Color.Parse(busterPrimaryColor);
                megaMan.BusterSecondaryColor = Color.Parse(busterSecondaryColor);
                megaMan.BusterSpeed = busterSpeed;
                megaMan.MaxBusterShots = busterShots;

                AtomicFireOptions atomicFire = rom.WeaponOptions.AtomicFire;
                atomicFire.PrimaryColor = Color.Parse(atomicFirePrimaryColor);
                atomicFire.SecondaryColor = Color.Parse(atomicFireSecondaryColor);
                atomicFire.Level1AmmoUsed = atomicFireLevel1Ammo;
                atomicFire.Level2ChargeTime = atomicFireLevel2ChargeTime;
                atomicFire.Level2AmmoUsed = atomicFireLevel2Ammo;
                atomicFire.Level3ChargeTime = atomicFireLevel3ChargeTime;
                atomicFire.Level3AmmoUsed = atomicFireLevel3Ammo;
                atomicFire.ProjectileSpeed = atomicFireSpeed;

                AirShooterOptions airShooter = rom.WeaponOptions.AirShooter;
                airShooter.PrimaryColor = Color.Parse(airShooterPrimaryColor);
                airShooter.SecondaryColor = Color.Parse(airShooterSecondaryColor);
                airShooter.AmmoUsed = airShooterAmmo;
                airShooter.ProjectileCount = airShooterShots;

                BubbleManOptions bubbleMan = rom.RobotMasterOptions.BubbleMan;
                bubbleMan.PrimaryColor = Color.Parse(bubbleManPrimaryColor);
                bubbleMan.SecondaryColor = Color.Parse(bubbleManSecondaryColor);

                AirManOptions airMan = rom.RobotMasterOptions.AirMan;
                airMan.PrimaryColor = Color.Parse(airManPrimaryColor);
                airMan.SecondaryColor = Color.Parse(airManSecondaryColor);
                airMan.ShotsBeforeJumping = airManShotsBeforeJumping;
                airMan.Jump1Distance = airManJump1Distance;
                airMan.Jump1Height = airManJump1Height;
                airMan.Jump2Distance = airManJump2Distance;
                airMan.Jump2Height = airManJump2Height;
                int tornadoCount = airManTornadoVertSpeed.Length;
                for (int i = 0; i < tornadoCount; i++)
                {
                    int patternIndex = i / 6;
                    TornadoPattern pattern = airMan.Patterns[patternIndex];
                    int tornadoIndex = i % 6;
                    Tornado tornado = pattern.Tornados[tornadoIndex];

                    tornado.VerticalVelocity = airManTornadoVertSpeed[i];
                    tornado.HorizontalVelocity = airManTornadoHorzSpeed[i];
                    tornado.FlightTime = (byte)airManTornadoFlightTime[i];
                }

                QuickManOptions quickMan = rom.RobotMasterOptions.QuickMan;
                quickMan.PrimaryColor = Color.Parse(quickManPrimaryColor);
                quickMan.SecondaryColor = Color.Parse(quickManSecondaryColor);
                quickMan.RunSpeed = quickManRunSpeed;
                quickMan.RunDuration = quickManRunDuration;
                quickMan.ProjectileCount = quickManProjectileCount;
                quickMan.ProjectileLaunchSpeed = quickManProjectileLaunchSpeed;
                quickMan.ProjectileReturnDelay = quickManProjectileReturnDelay;
                quickMan.ProjectileReturnSpeed = quickManProjectileReturnSpeed;

                HeatManOptions heatMan = rom.RobotMasterOptions.HeatMan;
                heatMan.PrimaryColor = Color.Parse(heatManPrimaryColor);
                heatMan.SecondaryColor = Color.Parse(heatManSecondaryColor);

                WoodManOptions woodMan = rom.RobotMasterOptions.WoodMan;
                woodMan.PrimaryColor = Color.Parse(woodManPrimaryColor);
                woodMan.SecondaryColor = Color.Parse(woodManSecondaryColor);

                MetalManOptions metalMan = rom.RobotMasterOptions.MetalMan;
                metalMan.PrimaryColor = Color.Parse(metalManPrimaryColor);
                metalMan.SecondaryColor = Color.Parse(metalManSecondaryColor);

                FlashManOptions flashMan = rom.RobotMasterOptions.FlashMan;
                flashMan.PrimaryColor = Color.Parse(flashManPrimaryColor);
                flashMan.SecondaryColor = Color.Parse(flashManSecondaryColor);
                flashMan.RunSpeed = flashManSpeed;
                flashMan.TimeStopperDelay = flashManTimeStopperDelay;
                flashMan.JumpDistance = flashManJumpDistance;
                flashMan.JumpHeight = flashManJumpHeight;
                flashMan.ProjectileCount = flashManProjectileCount;
                flashMan.ProjectileSpeed = flashManProjectileSpeed;

                CrashManOptions crashMan = rom.RobotMasterOptions.CrashMan;
                crashMan.PrimaryColor = Color.Parse(crashManPrimaryColor);
                crashMan.SecondaryColor = Color.Parse(crashManSecondaryColor);

                return File(rom.Bytes.ToArray(), "application/octet-stream", $"Custom {romFileName}");
            }
            finally
            {
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
        }
    }
}