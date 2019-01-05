namespace MegaMan2Configurator.Core
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
        public const int MegaManLadderClimbSpeedMsb = 0x0386EF; // higher is faster, 0 default
        public const int MegaManLadderClimbSpeedLsb = 0x0386F1; // higher is faster, c0 default
        public const int MegaManLadderDescendSpeedMsb = 0x03872E; // lower is faster, ff default
        public const int MegaManLadderDescendSpeedLsb = 0x038730; // lower is faster, 40 default
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
        public const int AirShooterColor1 = 0x03D31C;
        public const int AirShooterColor2 = 0x03D31D;
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
        // search ROM value for 2038 is megaman's eyes and face
    }
}
