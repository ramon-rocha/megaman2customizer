namespace MegaMan2Customizer.Core
{
    public class LeafShieldOptions : BaseWeaponOptions
    {
        public LeafShieldOptions(byte[] romBytes) : base(
            romBytes,
            primaryColorAddress: Addresses.LeafShieldColor1,
            secondaryColorAddress: Addresses.LeafShieldColor2,
            weaponNameAddress: Addresses.LeafShieldName,
            cutSceneLetterAddress: Addresses.LeafShieldCutSceneLetterCode,
            menuLetterAddress: Addresses.LeafShieldMenuLetterCode,
            weaponId: WeaponId.LeafShield)
        {
        }
    }
}
