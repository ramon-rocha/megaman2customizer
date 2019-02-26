using System;

namespace MegaMan2Customizer.Core
{
    public class AtomicFireOptions : BaseWeaponOptions
    {
        public override string Name
        {
            get => Text.DecodeWeaponName(_romBytes, Addresses.AtomicFireName);
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Weapon name cannot be null or empty");
                }
                if (value.Length > Defaults.MaxCutSceneTextLength)
                {
                    throw new ArgumentException($"Weapon name cannot be longer than {Defaults.MaxCutSceneTextLength} characters");
                }
                byte[] bytes = Text.EncodeCutScene(value);
                bytes.CopyTo(_romBytes, Addresses.AtomicFireName);
            }
        }

        public override char LetterCode
        {
            get => (char)_romBytes[Addresses.AtomicFireLetterCode1];
            set
            {
                _romBytes[Addresses.AtomicFireLetterCode1] = Text.EncodeCutScene(value);
                _romBytes[Addresses.AtomicFireLetterCode2] = Text.EncodeWeaponMenu(value);
            }
        }

        public override Color SecondaryColor
        {
            set
            {
                _romBytes[Addresses.AtomicFireColor2] = value.Value;
                _romBytes[Addresses.AtomicFireChargeColor1] = value.Value;
                _romBytes[Addresses.AtomicFireChargeColor2] = value.Value;
            }
        }

        public byte Level1AmmoUsed
        {
            get => _romBytes[Addresses.AtomicFireLevel1AmmoUsed];
            set => _romBytes[Addresses.AtomicFireLevel1AmmoUsed] = value;
        }

        public byte Level2ChargeTime
        {
            get => _romBytes[Addresses.AtomicFireLevel2ChargeTime];
            set => _romBytes[Addresses.AtomicFireLevel2ChargeTime] = value;
        }

        public byte Level2AmmoUsed
        {
            get => _romBytes[Addresses.AtomicFireLevel2AmmoUsed];
            set => _romBytes[Addresses.AtomicFireLevel2AmmoUsed] = value;
        }

        public byte Level3ChargeTime
        {
            get => _romBytes[Addresses.AtomicFireLevel3ChargeTime];
            set => _romBytes[Addresses.AtomicFireLevel3ChargeTime] = value;
        }

        public byte Level3AmmoUsed
        {
            get => _romBytes[Addresses.AtomicFireLevel3AmmoUsed];
            set => _romBytes[Addresses.AtomicFireLevel3AmmoUsed] = value;
        }

        public byte ProjectileSpeed
        {
            get => _romBytes[Addresses.AtomicFireProjectileSpeed];
            set => _romBytes[Addresses.AtomicFireProjectileSpeed] = value;
        }

        public AtomicFireOptions(byte[] romBytes) : base(romBytes, Addresses.AtomicFireColor1, Addresses.AtomicFireColor2, WeaponId.AtomicFire)
        {
        }
    }
}
