using System;

namespace MegaMan2Customizer.Core
{
    public class QuickBoomerangOptions : BaseWeaponOptions
    {
        public override string Name
        {
            get =>
                Text.DecodeWeaponName(_romBytes, Addresses.QuickBoomerangNameLine1) +
                Text.DecodeWeaponName(_romBytes, Addresses.QuickBoomerangNameLine2);
            set
            {
                throw new NotImplementedException();
            }
        }

        public QuickBoomerangOptions(byte[] romBytes) : base(
            romBytes,
            primaryColorAddress: Addresses.QuickBoomerangColor1,
            secondaryColorAddress: Addresses.QuickBoomerangColor2,
            weaponNameAddress: Addresses.QuickBoomerangNameLine1,
            cutSceneLetterAddress: Addresses.QuickBoomerangCutSceneLetterCode,
            menuLetterAddress: Addresses.QuickBoomerangMenuLetterCode,
            weaponId: WeaponId.QuickBoomerang)
        {
        }
    }
}
