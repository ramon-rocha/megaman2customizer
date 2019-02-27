namespace MegaMan2Customizer.Core
{
    public interface IWeaponOptions
    {
        Color PrimaryColor { get; }

        Color SecondaryColor { get; }

        string Name { get; }

        char LetterCode { get; }

        WeaponId WeaponId { get; }
    }
}
