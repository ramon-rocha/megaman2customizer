using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace MegaMan2Customizer.Core
{
    public class MegaMan2Rom
    {
        private readonly byte[] _bytes;
        public ImmutableArray<byte> Bytes => _bytes.ToImmutableArray();

        public StartMenuOptions StartMenu { get; }

        public MegaManOptions MegaMan { get; }

        public AllWeaponOptions Weapons { get; }

        public AllRobotMasterOptions RobotMasters { get; }

        public AllStageOptions Stages { get; }

        public byte LargeHealthPickupAmount => this.Bytes[Addresses.LargeHealthPickupAmount];

        public byte SmallHealthPickupAmount => this.Bytes[Addresses.SmallHealthPickupAmount];

        public MegaMan2Rom(string path) : this(File.ReadAllBytes(path)) { }

        public MegaMan2Rom(ImmutableArray<byte> bytes) : this(bytes.ToArray()) { }

        public MegaMan2Rom(byte[] bytes)
        {
            _bytes = new byte[bytes.Length];
            Array.Copy(bytes, _bytes, bytes.Length);
            this.StartMenu = new StartMenuOptions(_bytes);
            this.MegaMan = new MegaManOptions(_bytes);
            this.Weapons = new AllWeaponOptions(_bytes);
            this.RobotMasters = new AllRobotMasterOptions(_bytes);
            this.Stages = new AllStageOptions(_bytes);
        }

        public void SaveAs(string path) => File.WriteAllBytes(path, this.Bytes.ToArray());
    }
}
