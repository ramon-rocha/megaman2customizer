namespace MegaMan2Customizer.Core
{
    public class CrashBomberOptions : BaseWeaponOptions
    {
        public CrashBomberOptions(byte[] romBytes) : base(
            romBytes,
            primaryColorAddress: Addresses.CrashBombColor1,
            secondaryColorAddress: Addresses.CrashBombColor2,
            weaponNameAddress: Addresses.CrashBomberName,
            cutSceneLetterAddress: Addresses.CrashBomberCutSceneLetterCode,
            menuLetterAddress: Addresses.CrashBomberMenuLetterCode,
            weaponId: WeaponId.CrashBomb)
        {
        }
    }
}
