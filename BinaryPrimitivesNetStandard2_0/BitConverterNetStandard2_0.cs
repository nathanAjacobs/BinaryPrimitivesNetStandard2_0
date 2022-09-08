using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BinaryPrimitivesNetStandard2_0
{
    internal class BitConverterNetStandard2_0
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int SingleToInt32Bits(float value)
        {
            return *((int*)&value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe float Int32BitsToSingle(int value)
        {
            return *((float*)&value);
        }
    }
}
