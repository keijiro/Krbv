using Unity.Mathematics;
using System.Runtime.InteropServices;

namespace Krbv
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SNorm16x4
    {
        public uint lo;
        public uint hi;

        public SNorm16x4(float3 v)
        {
            var vi = math.clamp(v, -1, 1) * 0x7fff;
            lo = (uint)((ushort)vi.x) | ((uint)((ushort)vi.y) << 16);
            hi = (ushort)vi.z;
        }

        public static implicit operator SNorm16x4(float3 v) => new SNorm16x4(v);
    }

    public struct UNorm8x4
    {
        public uint data;

        public UNorm8x4(float3 v)
        {
            var vi = math.saturate(v) * 0xff;
            data = ((uint)vi.x) | (((uint)vi.y) << 8) | (((uint)vi.z) << 16);
        }

        public static implicit operator UNorm8x4(float3 v) => new UNorm8x4(v);

        public static readonly UNorm8x4 _100 = new UNorm8x4 { data = 0x000000ffu };
        public static readonly UNorm8x4 _010 = new UNorm8x4 { data = 0x0000ff00u };
        public static readonly UNorm8x4 _001 = new UNorm8x4 { data = 0x00ff0000u };
    }
}
