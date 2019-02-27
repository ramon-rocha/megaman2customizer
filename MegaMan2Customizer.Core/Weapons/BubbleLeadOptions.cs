namespace MegaMan2Customizer.Core
{
    public class BubbleLeadOptions : BaseWeaponOptions
    {
        public BubbleLeadOptions(byte[] romBytes) : base(
            romBytes,
            primaryColorAddress: Addresses.BubbleLeadColor1,
            secondaryColorAddress: Addresses.BubbleLeadColor2,
            weaponNameAddress: Addresses.BubbleLeadName,
            cutSceneLetterAddress: Addresses.BubbleLeadCutSceneLetterCode,
            menuLetterAddress: Addresses.BubbleLeadMenuLetterCode,
            weaponId: WeaponId.BubbleLead)
        {
        }
    }
}
