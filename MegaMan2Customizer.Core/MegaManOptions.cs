﻿namespace MegaMan2Customizer.Core;

public class MegaManOptions
{
    private readonly byte[] _romBytes;

    public byte StartingHealth
    {
        get => _romBytes[Addresses.MegaManStartingHealth];
        set => _romBytes[Addresses.MegaManStartingHealth] = value;
    }

    public byte MaxHealth
    {
        get => _romBytes[Addresses.MegaManMaxHealth];
        set => _romBytes[Addresses.MegaManMaxHealth] = value;
    }

    public byte MaxBusterShots
    {
        get => (byte)(_romBytes[Addresses.MegaManBusterMaxShots] - 1);
        set => _romBytes[Addresses.MegaManBusterMaxShots] = (byte)(value + 1);
    }

    public byte BusterSpeed
    {
        get => _romBytes[Addresses.MegaManBusterSpeed];
        set => _romBytes[Addresses.MegaManBusterSpeed] = value;
    }

    public decimal WalkSpeed
    {
        get => _romBytes.GetDecimal(Addresses.MegaManWalkSpeedWhole, Addresses.MegaManWalkSpeedFraction);
        set => _romBytes.SetDecimal(Addresses.MegaManWalkSpeedWhole, Addresses.MegaManWalkSpeedFraction, value);
    }

    public decimal JumpHorizontalSpeed
    {
        get => _romBytes.GetDecimal(Addresses.MegaManJumpHorizontalSpeedWhole, Addresses.MegaManJumpHorizontalSpeedFraction);
        set => _romBytes.SetDecimal(Addresses.MegaManJumpHorizontalSpeedWhole, Addresses.MegaManJumpHorizontalSpeedFraction, value);
    }

    public decimal LadderClimbSpeed
    {
        get => _romBytes.GetDecimal(Addresses.MegaManLadderClimbSpeedWhole, Addresses.MegaManLadderClimbSpeedFraction);
        set => _romBytes.SetDecimal(Addresses.MegaManLadderClimbSpeedWhole, Addresses.MegaManLadderClimbSpeedFraction, value);
    }

    public decimal LadderDescentSpeed
    {
        get => _romBytes.GetDecimal(Addresses.MegaManLadderDescentSpeedWhole, Addresses.MegaManLadderDescentSpeedFraction);
        set => _romBytes.SetDecimal(Addresses.MegaManLadderDescentSpeedWhole, Addresses.MegaManLadderDescentSpeedFraction, value);
    }

    public byte JumpHeight
    {
        get => _romBytes[Addresses.MegaManJumpHeight];
        set => _romBytes[Addresses.MegaManJumpHeight] = value;
    }

    public char BusterLetterCode
    {
        get => Text.DecodeWeaponMenu(_romBytes, Addresses.BusterLetterCode, 1)[0];
        set => _romBytes[Addresses.BusterLetterCode] = Text.EncodeWeaponMenu(value);
    }

    public Color BusterPrimaryColor
    {
        get => new(_romBytes[Addresses.BusterColor1]);
        set
        {
            byte v = value.Value;
            _romBytes[Addresses.BusterColor1] = v;
            _romBytes[Addresses.BusterColor1CutScene] = v;
            _romBytes[Addresses.BusterColor1CutSceneBoots] = v;
            _romBytes[Addresses.BusterColor1TitleScreen] = v;
        }
    }

    public Color BusterSecondaryColor
    {
        get => new(_romBytes[Addresses.BusterColor2]);
        set
        {
            byte v = value.Value;
            _romBytes[Addresses.BusterColor2] = v;
            _romBytes[Addresses.BusterColor2CutScene] = v;
            _romBytes[Addresses.BusterColor2CutSceneBoots] = v;
            _romBytes[Addresses.BusterColor2TitleScreen] = v;
        }
    }

    public MegaManOptions(byte[] romBytes) => _romBytes = romBytes;
}
