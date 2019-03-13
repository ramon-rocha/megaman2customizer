namespace MegaMan2Customizer.Core
{
    public class CrashBomberOptions : BaseWeaponOptions
    {
        public CrashBomberOptions(byte[] romBytes) : base(
            romBytes,
            primaryColorAddress: Addresses.CrashBomberColor1,
            secondaryColorAddress: Addresses.CrashBomberColor2,
            weaponNameAddress: Addresses.CrashBomberName,
            cutSceneLetterAddress: Addresses.CrashBomberCutSceneLetterCode,
            menuLetterAddress: Addresses.CrashBomberMenuLetterCode,
            weaponId: WeaponId.CrashBomber)
        {
        }
    }
}
