namespace MegaMan2Customizer.Core
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
        // search ROM value for 2038 is megaman's eyes and face

        public const int GetEquippedText1 = 0x037EAC; // "  GET EQUIPPED"
        public const int GetEquippedText2 = 0x037EBC; // "  WITH        "

        public const int MessageFromDrLightText1 = 0x037ECC; // " MESSAGE FROM "
        public const int MessageFromDrLightText2 = 0x037EDC; // " DR.LIGHT.    "

        public const int ItemCompletedText1 = 0x037EEC; // "COMPLETED!    "
        public const int ItemCompletedText2 = 0x037EFC; // "GET YOUR      "
        public const int ItemCompletedText3 = 0x037F0C; // "WEAPONS READY!"

        public const int AtomicFireCutSceneLetterCode = 0x037E22;
        public const int AtomicFireMenuLetterCode = 0x035651;
        public const int AtomicFireName = 0x037E2C;
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
        public const int AtomicFireSound = 0x03DDEC;
        public const int AtomicFireChargeLevel2Sound = 0x03DE46;
        public const int AtomicFireChargeLevel3Sound = 0x03DE47;
        public const int AtomicFireFullyChargedSound = 0x03DE48;

        public const int AirShooterCutSceneLetterCode = 0x037E23;
        public const int AirShooterMenuLetterCode = 0x03562;
        public const int AirShooterName = 0x037E3C;
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
        public const int AirShooterSound = 0x03DAE6;

        public const int LeafShieldName = 0x037E4C;
        public const int LeafShieldCutSceneLetterCode = 0x037E24;
        public const int LeafShieldMenuLetterCode = 0x035653;
        public const int LeafShieldColor1 = 0x03D320;
        public const int LeafShieldColor2 = 0x03D321;
        public const int LeafShieldDeployDelay = 0x03DEDA; // 12, use even numbers only
        public const int LeafShieldSoundDelay = 0x03DF1B; // 7
        public const int LeafShieldHorizSpeed = 0x03DF59; // 4
        public const int LeafShieldVertSpeed = 0x03DF7D; // 4
        public const int LeafShieldAmmoUsed = 0x03DF72; // 3
        public const int LeafShieldSound = 0x03DF1F;

        public const int BubbleLeadName = 0x037E5C;
        public const int BubbleLeadCutSceneLetterCode = 0x037E25;
        public const int BubbleLeadMenuLetterCode = 0x035654;
        public const int BubbleLeadColor1 = 0x03D324;
        public const int BubbleLeadColor2 = 0x03D325;
        public const int BubbleLeadHorizSpeed = 0x03D4AB; // 1
        public const int BubbleLeadSurfaceSpeed = 0x03DFA9; // 2
        public const int BubbleLeadHorizFallSpeed = 0x03DFC0; // 0
        public const int BubbleLeadVertFallSpeed = 0x03DFC8; // 0xFE
        public const int BubbleLeadVertSpeed = 0x03D4CF; // 2
        public const int BubbleLeadMaxShots = 0x03DB21; // 3
        public const int BubbleLeadSound = 0x03DB34;
        public const int BubbleLeadShotsPerAmmo = 0x03DB3D; // 2

        public const int QuickBoomerangNameLine1 = 0x037E6C;
        public const int QuickBoomerangNameLine2 = 0x037F5C;
        public const int QuickBoomerangCutSceneLetterCode = 0x037E26;
        public const int QuickBoomerangMenuLetterCode = 0x035655;
        public const int QuickBoomerangColor1 = 0x03D328;
        public const int QuickBoomerangColor2 = 0x03D329;
        public const int QuickBoomerangFireDelay = 0x03DB54; // 11
        public const int QuickBoomerangMaxShots = 0x03DB5C; // 5
        public const int QuickBoomerangSound = 0x03DB6F;
        public const int QuickBoomerangShotsPerAmmo = 0x03DB78; // 8
        public const int QuickBoomerangTravelDistance = 0x03DFE2; // 0x12
        public const int QuickBoomerangLaunchAngle = 0x03DFEA; // 0x4B
        public const int QuickBoomerangReturnAngle = 0x03E013; // 0x4B
        public const int QuickBoomerangBehavior = 0x03DFFF; // 0x40
        public const int QuickBoomerangFlightTime = 0x03E007; // 0x23

        public const int TimeStopperName = 0x037E7C;
        public const int TimeStopperCutSceneLetterCode = 0x037E27;
        public const int TimeStopperMenuLetterCode = 0x035656;
        public const int TimeStopperColor1 = 0x03D32C;
        public const int TimeStopperColor2 = 0x03D32D;
        public const int TimeStopperSound = 0x03DC59;
        public const int TimeStopperDrainRateDelay = 0x03E16E; // lower value drains ammo faster, default 0F
        public const int TimeStopperDelayBeforeDrain = 0x03D49D; // higher value is more time before drain starts, default 0F

        public const int MetalBladeName = 0x037E8C;
        public const int MetalBladeCutSceneLetterCode = 0x037E28;
        public const int MetalBladeCutMenuCode = 0x035657;
        public const int MetalBladeColor1 = 0x03D330;
        public const int MetalBladeColor2 = 0x03D331;
        public const int MetalBladeMaxshots = 0x03DBB6; // 4
        public const int MetalBladeSound = 0x03DBC9;
        public const int MetalBladeShotsPerAmmo = 0x03DBD2; // 4
        public const int MetalBladeVertSpeedUp = 0x03DC12; // 4
        public const int MetalBladeVertSpeedDown = 0x03DC13; // 0xFC
        public const int MetalBladeVertSpeedUpLeft = 0x03DC16; // 2
        public const int MetalBladeVertSpeedDownLeft = 0x03DC17; // 0xFD
        public const int MetalBladeVertSpeedUpRight = 0x03DC1A; // 2
        public const int MetalBladeVertSpeedDownRight = 0x03DC1B; // 0xFD
        public const int MetalBladeHorizSpeed = 0x03DC31; // 4
        public const int MetalBladeHorizSpeedLeft = 0x03DC35; // 4
        public const int MetalBladeHorizSpeedUpLeft = 0x03DC36; // 2
        public const int MetalBladeHorizSpeedDownLeft = 0x03DC37; // 2
        public const int MetalBladeHorizSpeedRight = 0x03DC39; // 4
        public const int MetalBladeHorizSpeedUpRight = 0x03DC3A; // 2
        public const int MetalBladeHorizSpeedDownRight = 0x03DC3B; // 2

        public const int CrashBomberName = 0x037E9C;
        public const int CrashBomberCutSceneLetterCode = 0x037E29;
        public const int CrashBomberMenuLetterCode = 0x035658;
        public const int CrashBombColor1 = 0x03D334;
        public const int CrashBombColor2 = 0x03D335;
        public const int CrashBombHorizSpeed = 0x03D4AD; // 4
        public const int CrashBombVertSpeed = 0x03D4D7; // 0
        public const int CrashBombAmmoUsed = 0x03DB99; // 4
        public const int CrashBombExplosionType = 0x03DB9F; // 2 or 3
        public const int CrashBombDetonationDelay = 0x03E09C; // 0x7E
        public const int CrashBombShootSound = 0x03DBA6;
        public const int CrashBombAttachSound = 0x03E089;
        public const int CrashBombExplodeSound = 0x03E0DA;

        public const int Item1Color1 = 0x03D338;
        public const int Item1Color2 = 0x03D339;
        public const int Item1BlinkDelay = 0x03E1AC;
        public const int Item1DespawnDelay = 0x03E1BF;
        public const int Item1SpeedFraction = 0x03D4C2; // 0x41

        public const int Item2Color1 = 0x03D33C;
        public const int Item2Color2 = 0x03D33D;

        public const int Item3Color1 = 0x03D340;
        public const int Item3Color2 = 0x03D341;

        public const int BubbleManColor1 = 0x00F4B6;
        public const int BubbleManColor2 = 0x00F4B7;
        public const int BubbleManMaxHeight = 0x02C707; // 0x50
        public const int BubbleManFallSpeed = 0x02C70B; // 0xFF
        public const int BubbleManRiseSpeed = 0x02C6D3; // 1
        public const int BubbleManShotDelay = 0x02C745; // 0x12
        public const int BubbleManProjectileHorzSpeedWhole = 0x03DA25; // 1
        public const int BubbleManProjectileHorzSpeedFraction = 0x03DA25; // 0
        public const int BubbleManProjectileVertLaunchSpeedWhole = 0x03DA4D; // 3
        public const int BubbleManProjectileVertLaunchSpeedFraction = 0x03DA4E; // 0x76
        public const int BubbleManProjectileVertBounceSpeedWhole = 0x03B747; // 3
        public const int BubbleManProjectileVertBounceSpeedFraction = 0x03B74C; // 0x76
        public const int BubbleManWeaponOnDefeat = 0x03C28C;
        public const int BubbleManItemOnDefeat = 0x03C294;

        public const int AirManNameIntro = 0x0346F5; // 0x024B1E (what is this? credits?)
        public const int AirManNameStageSelect1 = 0x02EF3E; // which one is line 2?
        public const int AirManColor1 = 0x0074B7; // blue
        public const int AirManColor2 = 0x0074B6; // yellow
        public const int AirManProjectileColor1 = 0x0074B4; // blue
        public const int AirManProjectileColor2 = 0x0074B3; // white
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
        public const int AirManWeaponOnDefeat = 0x03C28A;
        public const int AirManItemOnDefeat = 0x03C292;

        public const int QuickManColor1 = 0x0134C9;
        public const int QuickManColor2 = 0x0134C8;
        public const int QuickManProjectileCount = 0x02C86E; // 3
        public const int QuickManProjectileReturnDelay = 0x02C882; // 0x25
        public const int QuickManProjectileLaunchSpeed = 0x02C887; // 4
        public const int QuickManProjectileReturnSpeed = 0x03B726; // 4
        public const int QuickManJump1Height = 0x02C8A3; // 7
        public const int QuickManJump2Height = 0x02C8A4; // 8
        public const int QuickManJump3Height = 0x02C8A5; // 4
        public const int QuickManRunDuration = 0x02C8E4; // 0x3E
        public const int QuickManRunSpeed = 0x02C8DF; // 2
        public const int QuickManWeaponOnDefeat = 0x03C28D;
        public const int QuickManItemOnDefeat = 0x03C295;

        public const int HeatManColor1 = 0x0034B6;
        public const int HeatManColor2 = 0x0034B7;
        public const int HeatManProjectileColor1 = 0x0034B3;
        public const int HeatManProjectileColor2 = 0x0034B4;
        public const int HeatManProjectile1Height = 0x02C207; // 7
        public const int HeatManProjectile1Distance = 0x02C20A; // 0x3A
        public const int HeatManProjectile2Height = 0x02C208; // 5
        public const int HeatManProjectile2Distance = 0x02C20B; // 0x2E
        public const int HeatManProjectile3Height = 0x02C209; // 3
        public const int HeatManProjectile3Distance = 0x02C20C; // 0x1C
        public const int HeatManRushDelay1 = 0x02C29D; // 0x1F
        public const int HeatManRushDelay2 = 0x02C29E; // 0x3E
        public const int HeatManRushDelay3 = 0x02C29F; // 0x5D
        public const int HeatManRushSpeed = 0x02C253; // 4
        public const int HeatManWeaponOnDefeat = 0x03C289;
        public const int HeatManItemOnDefeat = 0x03C291;

        public const int WoodManColor1 = 0x00B4ED;
        public const int WoodManColor2 = 0x00B4EC;
        public const int WoodManLeafColor = 0x00B4EA;
        public const int WoodManLeafDelay = 0x02C537; // 0x12
        public const int WoodManJumpHeight = 0x02C5DD; // 4
        public const int WoodManJumpDistance = 0x02C5E2; // 1
        public const int WoodManProjectileSpeed = 0x02C5A9; // 4
        public const int WoodManFallingLeafCount = 0x02C553; // 3
        public const int WoodManFallingLeafHorzSpeed = 0x02C576; // 2
        public const int WoodManFallingLeafVertSpeed = 0x03B855; // 0x20 (smaller is faster)
        public const int WoodManWeaponOnDefeat = 0x03C28B;
        public const int WoodManItemOnDefeat = 0x03C293;

        public const int MetalManColor1 = 0x01B4A5;
        public const int MetalManColor2 = 0x01B4A4;
        public const int MetalManBladeColor = 0x01B4A1;
        public const int MetalManBladeSound = 0x02CC29;
        public const int MetalManProjectileSpeed = 0x02CC3F; // 4
        public const int MetalManJump1Height = 0x02CBB5; // 6
        public const int MetalManJump2Height = 0x02CBB6; // 5
        public const int MetalManJump3Height = 0x02CBB7; // 4
        public const int MetalManWeaponOnDefeat = 0x03C28F;
        public const int MetalManItemOnDefeat = 0x03C297;

        public const int FlashManColor1 = 0x0174B6; // bright white
        public const int FlashManColor2 = 0x0174B7; // indigo
        public const int FlashManRunSpeedWhole = 0x02C982; // default 1
        public const int FlashManRunSpeedFraction = 0x02C97D; // default 6
        public const int FlashManTimeStopperDelay = 0x02C98B; // default BB
        public const int FlashManJumpDistance = 0x02CAC6; // default 0
        public const int FlashManJumpHeight = 0x02CACE; // default 4
        public const int FlashManProjectileSpeed = 0x02CA81; // default 8
        public const int FlashManProjectileCount = 0x02CA09; // default 6
        public const int FlashManWeaponOnDefeat = 0x03C28E;
        public const int FlashManItemOnDefeat = 0x03C296;

        public const int CrashManColor1 = 0x01F4ED;
        public const int CrashManColor2 = 0x01F4EC;
        public const int CrashManWalkSpeedWhole = 0x02CCF7; // 0x47
        public const int CrashManWalkSpeedFraction = 0x02CCF2; // 1
        public const int CrashManJumpHeight = 0x02CD2A; // 6
        public const int CrashManProjectileSpeed = 0x02CDEE; // 6
        public const int CrashManWeaponOnDefeat = 0x03C290;
        public const int CrashManItemOnDefeat = 0x03C298;
    }
}
