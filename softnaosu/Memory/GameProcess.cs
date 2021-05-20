using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using softnaosu.Enums;
using softnaosu.Objects;
using softnaosu.Utils;

namespace softnaosu.Memory
{
    public class GameProcess
    {
        public MemoryManager Memory;

        public GameProcess(Process process) => Memory = new MemoryManager(process.Handle);

        public bool ScanPattern(byte?[] pattern, out IntPtr address)
        {
            address = IntPtr.Zero;
            
            var regions = EnumerateMemoryRegions();
            
            foreach (var region in regions)
            {
                var bytes = Memory.ReadBytes(region.BaseAddress, (int)region.RegionSize);
                if (FindPatternOffset(pattern, bytes) is var offset && offset != IntPtr.Zero)
                {
                    address = Extensions.AddIntPtr(region.BaseAddress, offset);

                    return true;
                }
            }

            return false;
        }

        private List<MemoryRegion> EnumerateMemoryRegions()
        {
            var regions = new List<MemoryRegion>();
            var address = IntPtr.Zero;

            // catch every accessible region in game memory
            while (MemoryManager.VirtualQueryEx(Memory.HandleProcess,
                address, out var mbi,
                (uint) Marshal.SizeOf(typeof(MemoryBasicInformation))) != 0)
            {
                if (mbi.State != State.MemFree && !mbi.Protect.HasFlag(Protect.PageGuard))
                    regions.Add(new MemoryRegion(mbi));

                address = Extensions.AddIntPtr(mbi.BaseAddress, mbi.RegionSize);
            }

            return regions;
        }

        private IntPtr FindPatternOffset(byte?[] pattern, byte[] target)
        {
            for (var i = 0; i + pattern.Length < target.Length; i++)
            {
                for (var j = 0; j < pattern.Length; j++)
                {
                    if (pattern[j] != null && pattern[j] != target[i + j])
                        break;

                    if (j + 1 == pattern.Length)
                        return (IntPtr) i;
                }
            }
            
            return IntPtr.Zero;
        }
    }
}