namespace MegaMan2Customizer.Core
{
    public class MetalBladeOptions : BaseWeaponOptions
    {
        public MetalBladeOptions(byte[] romBytes) : base(
            romBytes,
            primaryColorAddress: Addresses.MetalBladeColor1,
            secondaryColorAddress: Addresses.MetalBladeColor2,
            weaponNameAddress: Addresses.MetalBladeName,
            cutSceneLetterAddress: Addresses.MetalBladeCutSceneLetterCode,
            menuLetterAddress: Addresses.MetalBladeCutMenuCode,
            weaponId: WeaponId.MetalBlade)
        {
        }
    }
}
