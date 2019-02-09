﻿using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace MegaMan2Customizer.Core
{
    public class MegaManRom
    {
        private readonly byte[] _bytes;
        public ImmutableArray<byte> Bytes => _bytes.ToImmutableArray();

        public StartMenuOptions StartMenu { get; }

        public MegaManOptions MegaMan { get; }

        public WeaponOptions Weapons { get; }

        public RobotMasterOptions RobotMasters { get; }

        public byte LargeHealthPickupAmount => this.Bytes[Addresses.LargeHealthPickupAmount];

        public byte SmallHealthPickupAmount => this.Bytes[Addresses.SmallHealthPickupAmount];

        public MegaManRom(string path) : this(File.ReadAllBytes(path)) { }

        public MegaManRom(ImmutableArray<byte> bytes) : this(bytes.ToArray()) { }

        public MegaManRom(byte[] bytes)
        {
            _bytes = new byte[bytes.Length];
            Array.Copy(bytes, _bytes, bytes.Length);
            this.StartMenu = new StartMenuOptions(_bytes);
            this.MegaMan = new MegaManOptions(_bytes);
            this.Weapons = new WeaponOptions(_bytes);
            this.RobotMasters = new RobotMasterOptions(_bytes);
        }

        public void SaveAs(string path) => File.WriteAllBytes(path, this.Bytes.ToArray());
    }
}
