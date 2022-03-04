using MegaMan2Customizer.Core;
using MegaMan2Customizer.WebApp.Models;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MegaMan2Customizer.WebApp.Controllers;

public class RomController : Controller
{
    [HttpGet("editor")]
    public IActionResult Editor(RomEditorViewModel model) => View(model);

    [HttpPost("romdata")]
    public async Task<IActionResult> RomData([FromForm] RomEditorViewModel editor)
    {
        if (editor.RomFile == null)
        {
            return BadRequest();
        }

        this.ModelState.Clear();

        var stream = new MemoryStream();
        await editor.RomFile.CopyToAsync(stream);
        var rom = new MegaMan2Rom(stream.ToArray());

        MegaManOptions megaMan = rom.MegaMan;
        editor.MegaMan = new MegaManOptionsViewModel
        {
            StartingHealth = megaMan.StartingHealth,
            MaxHealth = megaMan.MaxHealth,
            RunningSpeed = megaMan.WalkSpeed,
            JumpHeight = megaMan.JumpHeight,
            JumpHorizontalSpeed = megaMan.JumpHorizontalSpeed,
            BusterLetterCode = megaMan.BusterLetterCode,
            BusterPrimaryColor = megaMan.BusterPrimaryColor.Name,
            BusterSecondaryColor = megaMan.BusterSecondaryColor.Name,
            BusterProjectileSpeed = megaMan.BusterSpeed,
            BusterMaxProjectiles = megaMan.MaxBusterShots
        };

        #region WeaponUpgrades
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
        #endregion WeaponUpgrades

        #region RobotMasters
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
            TornadoPatternViewModel patternViewModel = new();
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
        #endregion RobotMasters

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

        if (model.RomFile == null)
        {
            return BadRequest();
        }

        var stream = new MemoryStream();
        await model.RomFile.CopyToAsync(stream);
        var rom = new MegaMan2Rom(stream.ToArray());

        var megaMan = rom.MegaMan;
        megaMan.StartingHealth = model.MegaMan.StartingHealth;
        megaMan.MaxHealth = model.MegaMan.MaxHealth;
        megaMan.WalkSpeed = model.MegaMan.RunningSpeed;
        megaMan.JumpHeight = model.MegaMan.JumpHeight;
        megaMan.JumpHorizontalSpeed = model.MegaMan.JumpHorizontalSpeed;
        megaMan.BusterPrimaryColor = Color.Parse(model.MegaMan.BusterPrimaryColor);
        megaMan.BusterSecondaryColor = Color.Parse(model.MegaMan.BusterSecondaryColor);
        megaMan.BusterSpeed = model.MegaMan.BusterProjectileSpeed;
        megaMan.MaxBusterShots = model.MegaMan.BusterMaxProjectiles;
        megaMan.BusterLetterCode = model.MegaMan.BusterLetterCode;

        SetWeaponOptions(rom, model.Weapons.AtomicFire);
        SetWeaponOptions(rom, model.Weapons.AirShooter);
        SetWeaponOptions(rom, model.Weapons.LeafShield);
        SetWeaponOptions(rom, model.Weapons.BubbleLead);
        SetWeaponOptions(rom, model.Weapons.QuickBoomerang);
        SetWeaponOptions(rom, model.Weapons.TimeStopper);
        SetWeaponOptions(rom, model.Weapons.MetalBlade);
        SetWeaponOptions(rom, model.Weapons.CrashBomber);

        SetRobotMasterOptions(rom, model.RobotMasters.BubbleMan);
        SetRobotMasterOptions(rom, model.RobotMasters.AirMan);
        SetRobotMasterOptions(rom, model.RobotMasters.QuickMan);
        SetRobotMasterOptions(rom, model.RobotMasters.HeatMan);
        SetRobotMasterOptions(rom, model.RobotMasters.WoodMan);
        SetRobotMasterOptions(rom, model.RobotMasters.MetalMan);
        SetRobotMasterOptions(rom, model.RobotMasters.FlashMan);
        SetRobotMasterOptions(rom, model.RobotMasters.CrashMan);

        return File(rom.Bytes.ToArray(), "application/octet-stream", $"Custom {model.RomFileName}");
    }

    #region WeaponViewModelsToRom
    public void SetBaseWeaponOptions(BaseWeaponOptions weapon, BaseWeaponOptionsViewModel model)
    {
        weapon.Name = model.Name;
        weapon.LetterCode = model.LetterCode;
        weapon.PrimaryColor = Color.Parse(model.PrimaryColor);
        weapon.SecondaryColor = Color.Parse(model.SecondaryColor);
    }

    public void SetWeaponOptions(MegaMan2Rom rom, AtomicFireOptionsViewModel model)
    {
        var atomicFire = rom.Weapons.AtomicFire;
        SetBaseWeaponOptions(atomicFire, model);
        atomicFire.Level1AmmoUsed = model.Level1AmmoUsed;
        atomicFire.Level2ChargeTime = model.Level2ChargeTime;
        atomicFire.Level2AmmoUsed = model.Level2AmmoUsed;
        atomicFire.Level3ChargeTime = model.Level3ChargeTime;
        atomicFire.Level3AmmoUsed = model.Level3AmmoUsed;
        atomicFire.ProjectileSpeed = model.ProjectileSpeed;
    }

    public void SetWeaponOptions(MegaMan2Rom rom, AirShooterOptionsViewModel model)
    {
        var airShooter = rom.Weapons.AirShooter;
        SetBaseWeaponOptions(airShooter, model);
        airShooter.ProjectileCount = model.ProjectileCount;
        airShooter.ProjectileVerticalAcceleration = model.VerticalAcceleration;
        airShooter.Projectile1HorizontalSpeed = model.Projectile1HorizontalSpeed;
        airShooter.Projectile2HorizontalSpeed = model.Projectile2HorizontalSpeed;
        airShooter.Projectile3HorizontalSpeed = model.Projectile3HorizontalSpeed;
    }

    public void SetWeaponOptions(MegaMan2Rom rom, LeafShieldOptionsViewModel model)
    {
        var leafShield = rom.Weapons.LeafShield;
        SetBaseWeaponOptions(leafShield, model);
        leafShield.AmmoUsed = model.AmmoUsed;
        leafShield.DeployDelay = model.DeployDelay;
        leafShield.HorizontalSpeed = model.ProjectileSpeed;
        leafShield.VerticalSpeed = model.ProjectileSpeed;

    }

    public void SetWeaponOptions(MegaMan2Rom rom, BubbleLeadOptionsViewModel model)
    {
        var bubbleLead = rom.Weapons.BubbleLead;
        SetBaseWeaponOptions(bubbleLead, model);
        bubbleLead.HorizontalSpeed = model.HorizontalSpeed;
        bubbleLead.VerticalSpeed = model.VerticalSpeed;
        bubbleLead.HorizontalFallSpeed = model.HorizontalFallingSpeed;
        bubbleLead.VerticalFallSpeed = model.VerticalFallingSpeed;
        bubbleLead.MaxProjectiles = model.MaxProjectiles;
        bubbleLead.ShotsPerAmmo = model.ShotsPerAmmo;
        bubbleLead.SurfaceSpeed = model.SurfaceSpeed;
    }
    public void SetWeaponOptions(MegaMan2Rom rom, QuickBoomerangOptionsViewModel model)
    {
        var quickBoomerang = rom.Weapons.QuickBoomerang;
        SetBaseWeaponOptions(quickBoomerang, model);
        quickBoomerang.FireDelay = model.FireDelay;
        quickBoomerang.FlightTime = model.Time;
        quickBoomerang.LaunchAngle = model.LaunchAngle;
        quickBoomerang.MaxShots = model.MaxShots;
        quickBoomerang.ReturnAngle = model.ReturnAngle;
        quickBoomerang.ShotsPerAmmo = model.ShotsPerAmmo;
        quickBoomerang.TravelDistance = model.TravelDistance;
    }

    public void SetWeaponOptions(MegaMan2Rom rom, TimeStopperOptionsViewModel model)
    {
        var timeStopper = rom.Weapons.TimeStopper;
        SetBaseWeaponOptions(timeStopper, model);
        timeStopper.DelayBeforeDrain = model.DelayBeforeDrain;
        timeStopper.DrainRateDelay = model.DrainRateDelay;
    }

    public void SetWeaponOptions(MegaMan2Rom rom, MetalBladeOptionsViewModel model)
    {
        var metalBlade = rom.Weapons.MetalBlade;
        SetBaseWeaponOptions(metalBlade, model);
        metalBlade.MaxShots = model.MaxShots;
        metalBlade.ShotsPerAmmo = model.ShotsPerAmmo;
        metalBlade.Speed = model.ProjectileSpeed;
    }

    public void SetWeaponOptions(MegaMan2Rom rom, CrashBomberOptionsViewModel model)
    {
        var crashBomber = rom.Weapons.CrashBomber;
        SetBaseWeaponOptions(crashBomber, model);
        crashBomber.AmmoUsed = model.AmmoUsed;
        crashBomber.DetonationDelay = model.DetonationDelay;
        crashBomber.HorizontalSpeed = model.HorizontalSpeed;
        crashBomber.VerticalSpeed = model.VerticalSpeed;
    }
    #endregion WeaponViewModelsToRom

    #region RobotMasterViewModelsToRom
    public void SetBaseRobotMasterOptions(BaseRobotMasterOptions robotMaster, BaseRobotMasterOptionsViewModel model)
    {
        robotMaster.PrimaryColor = Color.Parse(model.PrimaryColor);
        robotMaster.SecondaryColor = Color.Parse(model.SecondaryColor);
        robotMaster.ItemOnDefeat = Enum.Parse<ItemId>(model.ItemOnDefeat);
        robotMaster.WeaponOnDefeat = Enum.Parse<WeaponId>(model.WeaponOnDefeat);
    }

    public void SetRobotMasterOptions(MegaMan2Rom rom, BubbleManOptionsViewModel model)
    {
        var bubbleMan = rom.RobotMasters.BubbleMan;
        SetBaseRobotMasterOptions(bubbleMan, model);
        bubbleMan.FallSpeed = model.FallSpeed;
        bubbleMan.RiseSpeed = model.RiseSpeed;
        bubbleMan.MaxHeight = model.MaxHeight;
        bubbleMan.BubbleBounceSpeed = model.BubbleBounceSpeed;
        bubbleMan.BubbleLaunchSpeed = model.BubbleLaunchSpeed;
        bubbleMan.ProjectileSpeed = model.ProjectileSpeed;
        bubbleMan.ShotDelay = model.ShotDelay;
    }

    public void SetRobotMasterOptions(MegaMan2Rom rom, AirManOptionsViewModel model)
    {
        var airMan = rom.RobotMasters.AirMan;
        SetBaseRobotMasterOptions(airMan, model);
        airMan.Jump1Distance = model.Jump1Distance;
        airMan.Jump1Height = model.Jump1Height;
        airMan.Jump2Distance = model.Jump2Distance;
        airMan.Jump2Height = model.Jump2Height;
        airMan.ShotsBeforeJumping = model.ShotsBeforeJumping;
        airMan.TornadoPrimaryColor = Color.Parse(model.TornadoPrimaryColor);
        airMan.TornadoSecondaryColor = Color.Parse(model.TornadoSecondaryColor);
        for (int i = 0; i < airMan.Patterns.Count; i++)
        {
            for (int j = 0; j < airMan.Patterns[i].Tornados.Count; j++)
            {
                airMan.Patterns[i].Tornados[j].VerticalVelocity = model.TornadoPatterns[i].Tornados[j].VerticalVelocity;
                airMan.Patterns[i].Tornados[j].HorizontalVelocity = model.TornadoPatterns[i].Tornados[j].HorizontalVelocity;
                airMan.Patterns[i].Tornados[j].FlightTime = model.TornadoPatterns[i].Tornados[j].FlightTime;
            }
        }
    }

    public void SetRobotMasterOptions(MegaMan2Rom rom, QuickManOptionsViewModel model)
    {
        var quickMan = rom.RobotMasters.QuickMan;
        SetBaseRobotMasterOptions(quickMan, model);
        quickMan.Jump1Height = model.Jump1Height;
        quickMan.Jump2Height = model.Jump2Height;
        quickMan.Jump3Height = model.Jump3Height;
        quickMan.RunSpeed = model.RunSpeed;
        quickMan.RunDuration = model.RunDuration;
        quickMan.ProjectileCount = model.ProjectileCount;
        quickMan.ProjectileLaunchSpeed = model.ProjectileLaunchSpeed;
        quickMan.ProjectileReturnDelay = model.ProjectileReturnDelay;
        quickMan.ProjectileReturnSpeed = model.ProjectileReturnSpeed;
    }

    public void SetRobotMasterOptions(MegaMan2Rom rom, HeatManOptionsViewModel model)
    {
        var heatMan = rom.RobotMasters.HeatMan;
        SetBaseRobotMasterOptions(heatMan, model);
        heatMan.Projectile1Distance = model.Projectile1Distance;
        heatMan.Projectile1Height = model.Projectile1Height;
        heatMan.Projectile2Distance = model.Projectile2Distance;
        heatMan.Projectile2Height = model.Projectile2Height;
        heatMan.Projectile3Distance = model.Projectile3Distance;
        heatMan.Projectile3Height = model.Projectile3Height;
        heatMan.RushDelay1 = model.RushDelay1;
        heatMan.RushDelay2 = model.RushDelay2;
        heatMan.RushDelay3 = model.RushDelay3;
        heatMan.RushSpeed = model.RushSpeed;
    }

    public void SetRobotMasterOptions(MegaMan2Rom rom, WoodManOptionsViewModel model)
    {
        var woodMan = rom.RobotMasters.WoodMan;
        SetBaseRobotMasterOptions(woodMan, model);
        woodMan.FallingLeafCount = model.FallingLeafCount;
        woodMan.FallingLeafHorizontalSpeed = model.FallingLeafHorizontalSpeed;
        woodMan.FallingLeafVerticalSpeed = model.FallingLeafVerticalSpeed;
        woodMan.ProjectileSpeed = model.ProjectileSpeed;
        woodMan.JumpHeight = model.JumpHeight;
        woodMan.JumpDistance = model.JumpDistance;
        woodMan.LeafDelay = model.LeafDelay;
        woodMan.LeafColor = Color.Parse(model.LeafColor);
    }

    public void SetRobotMasterOptions(MegaMan2Rom rom, MetalManOptionsViewModel model)
    {
        var metalMan = rom.RobotMasters.MetalMan;
        SetBaseRobotMasterOptions(metalMan, model);
        metalMan.BladeColor = Color.Parse(model.BladeColor);
        metalMan.Jump1Height = model.Jump1Height;
        metalMan.Jump2Height = model.Jump2Height;
        metalMan.Jump3Height = model.Jump3Height;
        metalMan.ProjectileSpeed = model.ProjectileSpeed;
    }

    public void SetRobotMasterOptions(MegaMan2Rom rom, FlashManOptionsViewModel model)
    {
        var flashMan = rom.RobotMasters.FlashMan;
        SetBaseRobotMasterOptions(flashMan, model);
        flashMan.RunSpeed = model.RunSpeed;
        flashMan.JumpDistance = model.JumpDistance;
        flashMan.JumpHeight = model.JumpHeight;
        flashMan.ProjectileCount = model.ProjectileCount;
        flashMan.ProjectileSpeed = model.ProjectileSpeed;
        flashMan.TimeStopperDelay = model.TimeStopperDelay;
    }

    public void SetRobotMasterOptions(MegaMan2Rom rom, CrashManOptionsViewModel model)
    {
        var crashMan = rom.RobotMasters.CrashMan;
        SetBaseRobotMasterOptions(crashMan, model);
        crashMan.JumpHeight = model.JumpHeight;
        crashMan.ProjectileSpeed = model.ProjectileSpeed;
        crashMan.WalkSpeed = model.WalkSpeed;
    }
    #endregion RobotMasterViewModelsToRom
}
