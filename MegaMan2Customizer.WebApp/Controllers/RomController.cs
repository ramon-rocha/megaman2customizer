using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using MegaMan2Customizer.Core;
using MegaMan2Customizer.WebApp.Models;

using Microsoft.AspNetCore.Mvc;

namespace MegaMan2Customizer.WebApp.Controllers
{
    public class RomController : Controller
    {
        [HttpGet("editor")]
        public IActionResult Editor(RomEditorViewModel model) => View(model);

        [HttpPost("romdata")]
        public async Task<IActionResult> RomData([FromForm] RomEditorViewModel editor)
        {
            /*
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }
            */

            var stream = new MemoryStream();
            await editor.RomFile.CopyToAsync(stream);
            var rom = new MegaMan2Rom(stream.ToArray());

            MegaManOptions megaMan = rom.MegaMan;
            editor.MegaMan = new MegaManOptionsViewModel
            {
                StartingHealth = megaMan.StartingHealth,
                MaxHealth = megaMan.MaxHealth,
                RunningSpeed = megaMan.Speed,
                JumpHeight = megaMan.JumpHeight,
                BusterLetterCode = megaMan.BusterLetterCode,
                BusterPrimaryColor = megaMan.BusterPrimaryColor.Name,
                BusterSecondaryColor = megaMan.BusterSecondaryColor.Name,
                BusterProjectileSpeed = megaMan.BusterSpeed,
                BusterMaxProjectiles = megaMan.MaxBusterShots
            };

            var atomicFire = rom.Weapons.AtomicFire;
            editor.Weapons.AtomicFire = new AtomicFireOptionsViewModel
            {
                Name = atomicFire.Name,
                LetterCode = atomicFire.LetterCode,
                PrimaryColor = atomicFire.PrimaryColor.Name,
                SecondaryColor = atomicFire.SecondaryColor.Name,
                Level1AmmoUsed = atomicFire.Level1AmmoUsed,
                Level2ChargeTime = atomicFire.Level2ChargeTime,
                Level2AmmoUsed = atomicFire.Level2AmmoUsed,
                Level3ChargeTime = atomicFire.Level3ChargeTime,
                Level3AmmoUsed = atomicFire.Level3AmmoUsed,
                ProjectileSpeed = atomicFire.ProjectileSpeed
            };

            var airShooter = rom.Weapons.AirShooter;
            editor.Weapons.AirShooter = new AirShooterOptionsViewModel
            {
                Name = airShooter.Name,
                LetterCode = airShooter.LetterCode,
                PrimaryColor = airShooter.PrimaryColor.Name,
                SecondaryColor = airShooter.SecondaryColor.Name,
                ProjectileCount = airShooter.ProjectileCount,
                Projectile1HorizontalSpeed = airShooter.Projectile1HorizontalSpeed,
                Projectile2HorizontalSpeed = airShooter.Projectile2HorizontalSpeed,
                Projectile3HorizontalSpeed = airShooter.Projectile3HorizontalSpeed,
                VerticalAcceleration = airShooter.ProjectileVerticalAcceleration,
                AmmoUsed = airShooter.AmmoUsed
            };

            var leafShield = rom.Weapons.LeafShield;
            editor.Weapons.LeafShield = new LeafShieldOptionsViewModel
            {
                Name = leafShield.Name,
                LetterCode = leafShield.LetterCode,
                PrimaryColor = leafShield.PrimaryColor.Name,
                SecondaryColor = leafShield.SecondaryColor.Name,
                AmmoUsed = leafShield.AmmoUsed,
                DeployDelay = leafShield.DeployDelay,
                ProjectileSpeed = leafShield.VerticalSpeed
            };

            var bubbleLead = rom.Weapons.BubbleLead;
            editor.Weapons.BubbleLead = new BubbleLeadOptionsViewModel
            {
                Name = bubbleLead.Name,
                LetterCode = bubbleLead.LetterCode,
                PrimaryColor = bubbleLead.PrimaryColor.Name,
                SecondaryColor = bubbleLead.SecondaryColor.Name,
                HorizontalSpeed = bubbleLead.HorizontalSpeed,
                VerticalSpeed = bubbleLead.VerticalSpeed,
                HorizontalFallingSpeed = bubbleLead.HorizontalFallSpeed,
                VerticalFallingSpeed = bubbleLead.VerticalFallSpeed,
                MaxProjectiles = bubbleLead.MaxProjectiles,
                ShotsPerAmmo = bubbleLead.ShotsPerAmmo,
                SurfaceSpeed = bubbleLead.SurfaceSpeed
            };

            var quickBoomerang = rom.Weapons.QuickBoomerang;
            editor.Weapons.QuickBoomerang = new QuickBoomerangOptionsViewModel
            {
                Name = quickBoomerang.Name,
                LetterCode = quickBoomerang.LetterCode,
                PrimaryColor = quickBoomerang.PrimaryColor.Name,
                SecondaryColor = quickBoomerang.SecondaryColor.Name,
                FireDelay = quickBoomerang.FireDelay,
                MaxShots = quickBoomerang.MaxShots,
                ShotsPerAmmo = quickBoomerang.ShotsPerAmmo,
                TravelDistance = quickBoomerang.TravelDistance,
                LaunchAngle = quickBoomerang.LaunchAngle,
                ReturnAngle = quickBoomerang.ReturnAngle
            };

            var timeStopper = rom.Weapons.TimeStopper;
            editor.Weapons.TimeStopper = new TimeStopperOptionsViewModel
            {
                Name = timeStopper.Name,
                LetterCode = timeStopper.LetterCode,
                PrimaryColor = timeStopper.PrimaryColor.Name,
                SecondaryColor = timeStopper.SecondaryColor.Name,
                DelayBeforeDrain = timeStopper.DelayBeforeDrain,
                DrainRateDelay = timeStopper.DrainRateDelay
            };

            var metalBlade = rom.Weapons.MetalBlade;
            editor.Weapons.MetalBlade = new MetalBladeOptionsViewModel
            {
                Name = metalBlade.Name,
                LetterCode = metalBlade.LetterCode,
                PrimaryColor = metalBlade.PrimaryColor.Name,
                SecondaryColor = metalBlade.SecondaryColor.Name,
                MaxShots = metalBlade.MaxShots,
                ProjectileSpeed = metalBlade.Speed, // TODO: split into different directions
                ShotsPerAmmo = metalBlade.ShotsPerAmmo
            };

            var crashBomber = rom.Weapons.CrashBomber;
            editor.Weapons.CrashBomber = new CrashBomberOptionsViewModel
            {
                Name = crashBomber.Name,
                LetterCode = crashBomber.LetterCode,
                PrimaryColor = crashBomber.PrimaryColor.Name,
                SecondaryColor = crashBomber.SecondaryColor.Name,
                HorizontalSpeed = crashBomber.HorizontalSpeed,
                VerticalSpeed = crashBomber.VerticalSpeed,
                DetonationDelay = crashBomber.DetonationDelay,
                AmmoUsed = crashBomber.AmmoUsed
            };

            var bubbleMan = rom.RobotMasters.BubbleMan;
            editor.RobotMasters.BubbleMan = new BubbleManOptionsViewModel
            {
                PrimaryColor = bubbleMan.PrimaryColor.Name,
                SecondaryColor = bubbleMan.SecondaryColor.Name,
                WeaponOnDefeat = bubbleMan.WeaponOnDefeat.ToString(),
                ItemOnDefeat = bubbleMan.ItemOnDefeat.ToString(),
                RiseSpeed = bubbleMan.RiseSpeed,
                MaxHeight = bubbleMan.MaxHeight,
                FallSpeed = bubbleMan.FallSpeed,
                ShotDelay = bubbleMan.ShotDelay,
                ProjectileSpeed = bubbleMan.ProjectileSpeed,
                BubbleLaunchSpeed = bubbleMan.BubbleLaunchSpeed,
                BubbleBounceSpeed = bubbleMan.BubbleBounceSpeed
            };

            var airMan = rom.RobotMasters.AirMan;
            editor.RobotMasters.AirMan = new AirManOptionsViewModel
            {
                PrimaryColor = airMan.PrimaryColor.Name,
                SecondaryColor = airMan.SecondaryColor.Name,
                WeaponOnDefeat = airMan.WeaponOnDefeat.ToString(),
                ItemOnDefeat = airMan.ItemOnDefeat.ToString(),
                TornadoPrimaryColor = airMan.TornadoPrimaryColor.Name,
                TornadoSecondaryColor = airMan.TornadoSecondaryColor.Name,
                ShotsBeforeJumping = airMan.ShotsBeforeJumping,
                Jump1Distance = airMan.Jump1Distance,
                Jump1Height = airMan.Jump1Height,
                Jump2Distance = airMan.Jump2Distance,
                Jump2Height = airMan.Jump2Height,
                TornadoPatterns = new List<TornadoPatternViewModel>()
            };
            foreach (TornadoPattern pattern in airMan.Patterns)
            {
                var patternViewModel = new TornadoPatternViewModel();
                patternViewModel.Tornados = new List<TornadoOptionsViewModel>();
                editor.RobotMasters.AirMan.TornadoPatterns.Add(patternViewModel);
                foreach (Tornado tornado in pattern.Tornados)
                {
                    var tornadoViewModel = new TornadoOptionsViewModel
                    {
                        VerticalVelocity = tornado.VerticalVelocity,
                        HorizontalVelocity = tornado.HorizontalVelocity,
                        FlightTime = tornado.FlightTime
                    };
                    patternViewModel.Tornados.Add(tornadoViewModel);
                }
            }

            var quickMan = rom.RobotMasters.QuickMan;
            editor.RobotMasters.QuickMan = new QuickManOptionsViewModel
            {
                PrimaryColor = quickMan.PrimaryColor.Name,
                SecondaryColor = quickMan.SecondaryColor.Name,
                WeaponOnDefeat = quickMan.WeaponOnDefeat.ToString(),
                ItemOnDefeat = quickMan.ItemOnDefeat.ToString(),
                RunSpeed = quickMan.RunSpeed,
                RunDuration = quickMan.RunDuration,
                Jump1Height = quickMan.Jump1Height,
                Jump2Height = quickMan.Jump2Height,
                Jump3Height = quickMan.Jump3Height,
                ProjectileCount = quickMan.ProjectileCount,
                ProjectileLaunchSpeed = quickMan.ProjectileLaunchSpeed,
                ProjectileReturnDelay = quickMan.ProjectileReturnDelay,
                ProjectileReturnSpeed = quickMan.ProjectileReturnSpeed
            };

            var heatMan = rom.RobotMasters.HeatMan;
            editor.RobotMasters.HeatMan = new HeatManOptionsViewModel
            {
                PrimaryColor = heatMan.PrimaryColor.Name,
                SecondaryColor = heatMan.SecondaryColor.Name,
                WeaponOnDefeat = heatMan.WeaponOnDefeat.ToString(),
                ItemOnDefeat = heatMan.ItemOnDefeat.ToString(),
                ProjectileColor1 = heatMan.ProjectileColor1.Name,
                ProjectileColor2 = heatMan.ProjectileColor2.Name,
                Projectile1Height = heatMan.Projectile1Height,
                Projectile1Distance = heatMan.Projectile1Distance,
                Projectile2Height = heatMan.Projectile2Height,
                Projectile2Distance = heatMan.Projectile2Distance,
                Projectile3Height = heatMan.Projectile3Height,
                Projectile3Distance = heatMan.Projectile3Distance,
                RushDelay1 = heatMan.RushDelay1,
                RushDelay2 = heatMan.RushDelay2,
                RushDelay3 = heatMan.RushDelay3,
                RushSpeed = heatMan.RushSpeed
            };

            var woodMan = rom.RobotMasters.WoodMan;
            editor.RobotMasters.WoodMan = new WoodManOptionsViewModel
            {
                PrimaryColor = woodMan.PrimaryColor.Name,
                SecondaryColor = woodMan.SecondaryColor.Name,
                WeaponOnDefeat = woodMan.WeaponOnDefeat.ToString(),
                ItemOnDefeat = woodMan.ItemOnDefeat.ToString(),
                LeafColor = woodMan.LeafColor.Name,
                ProjectileSpeed = woodMan.ProjectileSpeed,
                FallingLeafCount = woodMan.FallingLeafCount,
                FallingLeafHorizontalSpeed = woodMan.FallingLeafHorizontalSpeed,
                FallingLeafVerticalSpeed = woodMan.FallingLeafVerticalSpeed,
                LeafDelay = woodMan.LeafDelay,
                JumpHeight = woodMan.JumpHeight,
                JumpDistance = woodMan.JumpDistance
            };

            var metalMan = rom.RobotMasters.MetalMan;
            editor.RobotMasters.MetalMan = new MetalManOptionsViewModel
            {
                PrimaryColor = metalMan.PrimaryColor.Name,
                SecondaryColor = metalMan.SecondaryColor.Name,
                WeaponOnDefeat = metalMan.WeaponOnDefeat.ToString(),
                ItemOnDefeat = metalMan.ItemOnDefeat.ToString(),
                BladeColor = metalMan.BladeColor.Name,
                ProjectileSpeed = metalMan.ProjectileSpeed,
                Jump1Height = metalMan.Jump1Height,
                Jump2Height = metalMan.Jump2Height,
                Jump3Height = metalMan.Jump3Height
            };

            var flashMan = rom.RobotMasters.FlashMan;
            editor.RobotMasters.FlashMan = new FlashManOptionsViewModel
            {
                PrimaryColor = flashMan.PrimaryColor.Name,
                SecondaryColor = flashMan.SecondaryColor.Name,
                WeaponOnDefeat = flashMan.WeaponOnDefeat.ToString(),
                ItemOnDefeat = flashMan.ItemOnDefeat.ToString(),
                RunSpeed = flashMan.RunSpeed,
                TimeStopperDelay = flashMan.TimeStopperDelay,
                JumpHeight = flashMan.JumpHeight,
                JumpDistance = flashMan.JumpDistance,
                ProjectileSpeed = flashMan.ProjectileSpeed,
                ProjectileCount = flashMan.ProjectileCount
            };

            var crashMan = rom.RobotMasters.CrashMan;
            editor.RobotMasters.CrashMan = new CrashManOptionsViewModel
            {
                PrimaryColor = crashMan.PrimaryColor.Name,
                SecondaryColor = crashMan.SecondaryColor.Name,
                WeaponOnDefeat = crashMan.WeaponOnDefeat.ToString(),
                ItemOnDefeat = crashMan.ItemOnDefeat.ToString(),
                WalkSpeed = crashMan.WalkSpeed,
                JumpHeight = crashMan.JumpHeight,
                ProjectileSpeed = crashMan.ProjectileSpeed
            };

            return PartialView("_RomData", editor);
        }

        [HttpPost("rom")]
        public async Task<IActionResult> CreateCustomRom(RomEditorViewModel model)
        {
            /*
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }
            */

            var stream = new MemoryStream();
            await model.RomFile.CopyToAsync(stream);
            var rom = new MegaMan2Rom(stream.ToArray());

            //TODO: set rom values from model

            return File(rom.Bytes.ToArray(), "application/octet-stream", $"Custom {model.RomFileName}");
        }
    }
}