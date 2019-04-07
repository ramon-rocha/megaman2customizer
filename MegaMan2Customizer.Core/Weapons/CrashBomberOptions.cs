namespace MegaMan2Customizer.Core
{
    public class CrashBomberOptions : BaseWeaponOptions
    {
        public byte HorizontalSpeed
        {
            get => _romBytes[Addresses.CrashBomberHorizSpeed];
            set => _romBytes[Addresses.CrashBomberHorizSpeed] = value;
        }

        public byte VerticalSpeed
        {
            get => _romBytes[Addresses.CrashBomberVertSpeed];
            set => _romBytes[Addresses.CrashBomberVertSpeed] = value;
        }

        public byte AmmoUsed
        {
            get => _romBytes[Addresses.CrashBomberAmmoUsed];
            set => _romBytes[Addresses.CrashBomberAmmoUsed] = value;
        }

        public byte DetonationDelay
        {
            get => _romBytes[Addresses.CrashBomberDetonationDelay];
            set => _romBytes[Addresses.CrashBomberDetonationDelay] = value;
        }

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
