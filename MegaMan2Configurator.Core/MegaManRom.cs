using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace MegaMan2Configurator.Core
{
    public class MegaManRom
    {
        private readonly byte[] _bytes;
        public ImmutableArray<byte> Bytes => _bytes.ToImmutableArray();

        public StartMenuOptions StartMenuOptions { get; }

        public MegaManOptions MegaManOptions { get; }

        public byte LargeHealthPickupAmount => this.Bytes[Addresses.LargeHealthPickupAmount];

        public byte SmallHealthPickupAmount => this.Bytes[Addresses.SmallHealthPickupAmount];

        public MegaManRom(string path) : this(File.ReadAllBytes(path)) { }

        public MegaManRom(byte[] bytes)
        {
            _bytes = new byte[bytes.Length];
            Array.Copy(bytes, _bytes, bytes.Length);
            this.StartMenuOptions = new StartMenuOptions(_bytes);
            this.MegaManOptions = new MegaManOptions(_bytes);
        }

        public void SaveAs(string path) => File.WriteAllBytes(path, this.Bytes.ToArray());
    }
}
