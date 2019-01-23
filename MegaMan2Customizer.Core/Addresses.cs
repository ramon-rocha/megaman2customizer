﻿namespace MegaMan2Customizer.Core
{
    public static class Addresses
    {
        public const int LargeHealthPickupAmount = 0x0382FD;
        public const int SmallHealthPickupAmount = 0x038301;

        public const int MegaManStartingHealth = 0x0380D5; // 28, does not show beyond 28, doesn't show full below 28
        public const int MegaManMaxHealth = 0x038315; // does not apply when using E tank, health refill doesn't go past 28

        // https://www.smwcentral.net/?p=viewthread&t=57100&page=1&pid=928995#p928995
        public const int MegaManBusterMaxShots = 0x03DA83;
        // http://www.romhacking.net/hacks/4093/
        public const int MegaManBusterSpeed = 0x03D4A7; // higher is faster, 4 default
        // http://acmlm.kafuka.org/board/thread.php?id=7941
        public const int RobotMasterHealthFillDelay = 0x02C142; // smaller is faster, 3 default
        public const int MegaManHealthFillDelay = 0x03831B; // smaller is faster, 7 default
        public const int MegaManHealthFillDelayMenu = 0x0352B2; // smaller is faster, 7 default 
        public const int MegaManWeaponFillDelay = 0x03835A;
        //http://acmlm.kafuka.org/board/thread.php?id=6020&page=34
        public const int MegaManLadderClimbSpeedWhole = 0x0386EF; // higher is faster, 0 default
        public const int MegaManLadderClimbSpeedFraction = 0x0386F1; // higher is faster, c0 default
        public const int MegaManLadderDescentSpeedWhole = 0x03872E; // lower is faster, ff default
        public const int MegaManLadderDescentSpeedFraction = 0x038730; // lower is faster, 40 default
        public const int MegaManFirstStepSpeed = 0x038920; // higher is faster, default 0
        public const int MegaManWalkSpeed = 0x038921; // higher is faster, default 1
        public const int MegaManJumpHorizontalSpeed = 0x038922; // higher is faster, default 1, TODO: check x38923 as well
        public const int MegaManJumpHeight = 0x038A81; // higher is...higher.

        public const int MegaManStandingHorizontalSpeed = 0x03891F; // default is 0, non zero value means Mega Man slides on the ground all the time, higher is faster

        public const int MegaManLastStepSpeed = 0x038923; // higher is faster, default 0
        public const int MegaManSpeedOnLanding = 0x038924; // higher is faster, default 0

        public const int StartMenuBorderColor = 0x036F0A; // 0x0357 in RAM 
        public const int StartMenuBackgroundColor = 0x036F0B; // 0x0358 in RAM
        public const int StartMenuShadowColor = 0x036F0C; // 0x0359 in RAM

        public const int StageSelectTextColor = 0x0344AA;
        public const int StageSelectBackgroundColor = 0x0344AB;
        public const int StageSelectStripeColor = 0x0344AC; // shared with some shades for air man's portrait
        // there are a bunch of other colors near here for robot master portrait colors

        public const int RobotMasterIntroBackgroundColor = 0x034186;
        public const int RobotMasterIntroStripeColor = 0x03418B;

        public const int BusterColor1 = 0x03D314; // 0x0368 in RAM is MegaMan's current color
        public const int BusterColor2 = 0x03D315;

        public const int AtomicFireColor1 = 0x03D318;
        public const int AtomicFireColor2 = 0x03D319; // also apply to 0x03DE4A and 0x03DE4C for charging shots
        public const int AtomicFireChargeColor1 = 0x03DE4A; // becomes secondary color after shooting so should match 0x03D319
        public const int AtomicFireChargeColor2 = 0x03DE4C;
        public const int AtomicFireLevel1AmmoUsed = 0x03DE55; // default 1
        public const int AtomicFireLevel2AmmoUsed = 0x03DE56; // default 6
        public const int AtomicFireLevel3AmmoUsed = 0x03DE57; // default 10
        public const int AtomicFireLevel2ChargeTime = 0x03DD61; // default 0x7D
        public const int AtomicFireLevel3ChargeTime = 0x03DD67; // default 0xBB
        public const int AtomicFireProjectileSpeed = 0x03DDF1; // default 4

        public const int AirShooterColor1 = 0x03D31C;
        public const int AirShooterColor2 = 0x03D31D;
        public const int AirShooterProjectileCount = 0x03DAD6; // default 4
        public const int AirShooterAmmoUsed = 0x03DAEE; // default 2
        public const int AirShooterVertAccelFraction = 0x03DE6E; // default 10
        public const int AirShooterVertAccelWhole = 0x03DE76; // default 0
        public const int AirShooterHorizSpeedFraction1 = 0x03DE7E; // default 19
        public const int AirShooterHorizSpeedFraction2 = 0x03DE7F; // default 99
        public const int AirShooterHorizSpeedFraction3 = 0x03DE80; // default 33
        public const int AirShooterHorizSpeedWhole1 = 0x03DE81; // default 1
        public const int AirShooterHorizSpeedWhole2 = 0x03DE82; // default 1
        public const int AirShooterHorizSpeedWhole3 = 0x03DE83; // default 2

        public const int LeafShieldColor1 = 0x03D320;
        public const int LeafShieldColor2 = 0x03D321;

        public const int BubbleLeadColor1 = 0x03D324;
        public const int BubbleLeadColor2 = 0x03D325;

        public const int QuickBoomerangColor1 = 0x03D328;
        public const int QuickBoomerangColor2 = 0x03D329;

        public const int TimeStopperColor1 = 0x03D32C;
        public const int TimeStopperColor2 = 0x03D32D;

        public const int MetalBladeColor1 = 0x03D330;
        public const int MetalBladeColor2 = 0x03D331;

        public const int CrashBombColor1 = 0x03D334;
        public const int CrashBombColor2 = 0x03D335;

        public const int Item1Color1 = 0x03D338;
        public const int Item1Color2 = 0x03D339;

        public const int Item2Color1 = 0x03D33C;
        public const int Item2Color2 = 0x03D33D;

        public const int Item3Color1 = 0x03D340;
        public const int Item3Color2 = 0x03D341;

        public const int TimeStopperDrainRateDelay = 0x03E16E; // lower value drains ammo faster, default 0F
        public const int TimeStopperDelayBeforeDrain = 0x03D49D; // higher value is more time before drain starts, default 0F
                                                                 // search ROM value for 2038 is megaman's eyes and face

        public const int FlashManColor1 = 0x0174B6; // bright white
        public const int FlashManColor2 = 0x0174B7; // indigo
        public const int FlashManRunSpeedWhole = 0x02C982; // default 1
        public const int FlashManRunSpeedFraction = 0x02C97D; // default 6
        public const int FlashManTimeStopperDelay = 0x02C98B; // default BB
        public const int FlashManJumpDistance = 0x02CAC6; // default 0
        public const int FlashManJumpHeight = 0x02CACE; // default 4
        public const int FlashManProjectileSpeed = 0x02CA81; // default 8
        public const int FlashManProjectileCount = 0x02CA09; // default 6

        public const int AirManColor1 = 0x0074B7; // blue
        public const int AirManColor2 = 0x0074B6; // bright yellow
        public const int AirManProjectileColor1 = 0x0074B3;
        public const int AirManProjectileColor2 = 0x0074B4;
        public const int AirManShotsBeforeJumping = 0x02C30C; // default 3
        public const int AirManJump1HeightWhole = 0x02C4E0; // default 4
        public const int AirManJump1HeightFraction = 0x02C4DD; // default 0xE6
        public const int AirManJump1DistanceWhole = 0x02C4E6; // default 1
        public const int AirManJump1DistanceFraction = 0x02C4E3; // default 0x39
        public const int AirManJump2HeightWhole = 0x02C4E1; // default 7
        public const int AirManJump2HeightFraction = 0x02C4DE; // default 76
        public const int AirManJump2DistanceWhole = 0x02C4E7; // default 1
        public const int AirManJump2DistanceFraction = 0x02C4E4; // default 0x9A
        public const int AirManTornadoVertSpeedWhole0 = 0x02C3B1; // number of entries = 30
        public const int AirManTornadoVertSpeedFraction0 = 0x02C393; // number of entries = 30
        public const int AirManTornadoHorzSpeedWhole0 = 0x02C3ED; // number of entries = 30
        public const int AirManTornadoHorzSpeedFraction0 = 0x02C3CF; // number of entries = 30
        public const int AirManTornadoFlightTime0 = 0x02C40B; // number of entries = 30

        public const int QuickManColor1 = 0x0134C8;
        public const int QuickManColor2 = 0x0134C9;

        public const int HeatManColor1 = 0x0034B6;
        public const int HeatManColor2 = 0x0034B7;
        public const int HeatManProjectileColor1 = 0x0034B3;
        public const int HeatManProjectileColor2 = 0x0034B4;

        public const int BubbleManColor1 = 0x00F4B6;
        public const int BubbleManColor2 = 0x00F4B7;

        public const int CrashManColor1 = 0x01F4EC;
        public const int CrashManColor2 = 0x01F4ED;

        public const int WoodManColor1 = 0x00B4EC;
        public const int WoodManColor2 = 0x00B4ED;
        public const int WoodManLeafColor = 0x00B4EA;

        public const int MetalManColor1 = 0x01B4A4;
        public const int MetalManColor2 = 0x01B4A5;
        public const int MetalManBladeColor = 0x01B4A1;
    }
}
