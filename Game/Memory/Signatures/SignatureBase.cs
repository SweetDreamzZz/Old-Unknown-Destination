using System;
using softnaosu.Game.Memory;
using softnaosu.Game.Utils;

namespace softnaosu.Game.Signatures
{
    public class SignatureBase
    {
        public string Pattern;
        public IntPtr Offset;

        public IntPtr GetBaseAddress()
        {
            MemoryManager.FindAddressBySignaturePattern(Pattern, out var signatureAddress);

            return Extensions.Add(signatureAddress, Offset);
        }
    }
}