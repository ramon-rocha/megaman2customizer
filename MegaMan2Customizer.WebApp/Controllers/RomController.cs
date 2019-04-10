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
        public async Task<IActionResult> RomData(RomEditorViewModel model)
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

            var megaMan = rom.MegaMan;
            model.MegaManStartingHealth = megaMan.StartingHealth;
            model.MegaManMaxHealth = megaMan.MaxHealth;
            model.MegaManRunningSpeed = megaMan.Speed;
            model.MegaManJumpHeight = megaMan.JumpHeight;
            model.MegaBusterLetterCode = megaMan.BusterLetterCode;
            model.MegaBusterPrimaryColor = megaMan.BusterPrimaryColor.Name;
            model.MegaBusterSecondaryColor = megaMan.BusterSecondaryColor.Name;
            model.MegaBusterProjectileSpeed = megaMan.BusterSpeed;
            model.MegaBusterMaxProjectiles = megaMan.MaxBusterShots;

            var atomicFire = rom.Weapons.AtomicFire;
            model.AtomicFireName = atomicFire.Name;
            model.AtomicFireLetterCode = atomicFire.LetterCode;
            model.AtomicFirePrimaryColor = atomicFire.PrimaryColor.Name;
            model.AtomicFireSecondaryColor = atomicFire.SecondaryColor.Name;
            model.AtomicFireLevel1AmmoUsed = atomicFire.Level1AmmoUsed;
            model.AtomicFireLevel2ChargeTime = atomicFire.Level2ChargeTime;
            model.AtomicFireLevel2AmmoUsed = atomicFire.Level2AmmoUsed;
            model.AtomicFireLevel3ChargeTime = atomicFire.Level3ChargeTime;
            model.AtomicFireLevel3AmmoUsed = atomicFire.Level3AmmoUsed;
            model.AtomicFireProjectileSpeed = atomicFire.ProjectileSpeed;

            var airShooter = rom.Weapons.AirShooter;
            model.AirShooterName = airShooter.Name;
            model.AirShooterLetterCode = airShooter.LetterCode;
            model.AirShooterPrimaryColor = airShooter.PrimaryColor.Name;
            model.AirShooterSecondaryColor = airShooter.SecondaryColor.Name;
            model.AirShooterProjectileCount = airShooter.ProjectileCount;
            model.AirShooterProjectile1HorizontalSpeed = airShooter.Projectile1HorizontalSpeed;
            model.AirShooterProjectile2HorizontalSpeed = airShooter.Projectile2HorizontalSpeed;
            model.AirShooterProjectile3HorizontalSpeed = airShooter.Projectile3HorizontalSpeed;
            model.AirShooterVerticalAcceleration = airShooter.ProjectileVerticalAcceleration;
            model.AirShooterAmmoUsed = airShooter.AmmoUsed;

            var leafShield = rom.Weapons.LeafShield;
            model.LeafShieldName = leafShield.Name;
            model.LeafShieldLetterCode = leafShield.LetterCode;
            model.LeafShieldPrimaryColor = leafShield.PrimaryColor.Name;
            model.LeafShieldSecondaryColor = leafShield.SecondaryColor.Name;
            model.LeafShieldAmmoUsed = leafShield.AmmoUsed;
            model.LeafShieldDeployDelay = leafShield.DeployDelay;
            model.LeafShieldProjectileSpeed = leafShield.VerticalSpeed;

            var bubbleLead = rom.Weapons.BubbleLead;
            model.BubbleLeadName = bubbleLead.Name;
            model.BubbleLeadLetterCode = bubbleLead.LetterCode;
            model.BubbleLeadPrimaryColor = bubbleLead.PrimaryColor.Name;
            model.BubbleLeadSecondaryColor = bubbleLead.SecondaryColor.Name;
            model.BubbleLeadHorizontalSpeed = bubbleLead.HorizontalSpeed;
            model.BubbleLeadVerticalSpeed = bubbleLead.VerticalSpeed;
            model.BubbleLeadHorizontalFallingSpeed = bubbleLead.HorizontalFallSpeed;
            model.BubbleLeadVerticalFallingSpeed = bubbleLead.VerticalFallSpeed;
            model.BubbleLeadMaxProjectiles = bubbleLead.MaxProjectiles;
            model.BubbleLeadShotsPerAmmo = bubbleLead.ShotsPerAmmo;
            model.BubbleLeadSurfaceSpeed = bubbleLead.SurfaceSpeed;

            var quickBoomerang = rom.Weapons.QuickBoomerang;
            model.QuickBoomerangName = quickBoomerang.Name;
            model.QuickBoomerangLetterCode = quickBoomerang.LetterCode;
            model.QuickBoomerangPrimaryColor = quickBoomerang.PrimaryColor.Name;
            model.QuickBoomerangSecondaryColor = quickBoomerang.SecondaryColor.Name;
            model.QuickBoomerangFireDelay = quickBoomerang.FireDelay;
            model.QuickBoomerangMaxShots = quickBoomerang.MaxShots;
            model.QuickBoomerangShotsPerAmmo = quickBoomerang.ShotsPerAmmo;
            model.QuickBoomerangTravelDistance = quickBoomerang.TravelDistance;
            model.QuickBoomerangLaunchAngle = quickBoomerang.LaunchAngle;
            model.QuickBoomerangReturnAngle = quickBoomerang.ReturnAngle;

            var timeStopper = rom.Weapons.TimeStopper;
            model.TimeStopperName = timeStopper.Name;
            model.TimeStopperLetterCode = timeStopper.LetterCode;
            model.TimeStopperPrimaryColor = timeStopper.PrimaryColor.Name;
            model.TimeStopperSecondaryColor = timeStopper.SecondaryColor.Name;
            model.TimeStopperDelayBeforeDrain = timeStopper.DelayBeforeDrain;
            model.TimeStopperDrainRateDelay = timeStopper.DrainRateDelay;

            var metalBlade = rom.Weapons.MetalBlade;
            model.MetalBladeName = metalBlade.Name;
            model.MetalBladeLetterCode = metalBlade.LetterCode;
            model.MetalBladePrimaryColor = metalBlade.PrimaryColor.Name;
            model.MetalBladeSecondaryColor = metalBlade.SecondaryColor.Name;
            model.MetalBladeMaxShots = metalBlade.MaxShots;
            model.MetalBladeProjectileSpeed = metalBlade.Speed; // TODO: split into different directions
            model.MetalBladeShotsPerAmmo = metalBlade.ShotsPerAmmo;

            var crashBomber = rom.Weapons.CrashBomber;
            model.CrashBomberName = crashBomber.Name;
            model.CrashBomberLetterCode = crashBomber.LetterCode;
            model.CrashBomberPrimaryColor = crashBomber.PrimaryColor.Name;
            model.CrashBomberSecondaryColor = crashBomber.SecondaryColor.Name;
            model.CrashBomberHorizontalSpeed = crashBomber.HorizontalSpeed;
            model.CrashBomberVerticalSpeed = crashBomber.VerticalSpeed;
            model.CrashBomberDetonationDelay = crashBomber.DetonationDelay;
            model.CrashBomberAmmoUsed = crashBomber.AmmoUsed;

            var bubbleMan = rom.RobotMasters.BubbleMan;
            model.BubbleManPrimaryColor = bubbleMan.PrimaryColor.Name;
            model.BubbleManSecondaryColor = bubbleMan.SecondaryColor.Name;
            model.BubbleManRiseSpeed = bubbleMan.RiseSpeed;
            model.BubbleManMaxHeight = bubbleMan.MaxHeight;
            model.BubblemanFallSpeed = bubbleMan.FallSpeed;
            model.BubblemanShotDelay = bubbleMan.ShotDelay;
            model.BubblemanProjectileSpeed = bubbleMan.ProjectileSpeed;
            model.BubblemanBubbleLaunchSpeed = bubbleMan.BubbleLaunchSpeed;

            var airMan = rom.RobotMasters.AirMan;
            model.AirManPrimaryColor = airMan.PrimaryColor.Name;
            model.AirManSecondaryColor = airMan.SecondaryColor.Name;

            var quickMan = rom.RobotMasters.QuickMan;
            model.QuickManPrimaryColor = quickMan.PrimaryColor.Name;
            model.QuickManSecondaryColor = quickMan.SecondaryColor.Name;

            var heatMan = rom.RobotMasters.HeatMan;
            model.HeatManPrimaryColor = heatMan.PrimaryColor.Name;
            model.HeatManSecondaryColor = heatMan.SecondaryColor.Name;

            var woodMan = rom.RobotMasters.WoodMan;
            model.WoodManPrimaryColor = woodMan.PrimaryColor.Name;
            model.WoodManSecondaryColor = woodMan.SecondaryColor.Name;

            var metalMan = rom.RobotMasters.MetalMan;
            model.MetalManPrimaryColor = metalMan.PrimaryColor.Name;
            model.MetalManSecondaryColor = metalMan.SecondaryColor.Name;

            var flashMan = rom.RobotMasters.FlashMan;
            model.FlashManPrimaryColor = flashMan.PrimaryColor.Name;
            model.FlashManSecondaryColor = flashMan.SecondaryColor.Name;

            var crashMan = rom.RobotMasters.CrashMan;
            model.CrashManPrimaryColor = crashMan.PrimaryColor.Name;
            model.CrashManSecondaryColor = crashMan.SecondaryColor.Name;

            return PartialView("_RomData", model);
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