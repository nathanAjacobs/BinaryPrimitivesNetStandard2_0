using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BinaryPrimitivesNetStandard2_0
{
    public class BinaryPrimitivesNetStandard2_0
    {
        /// <summary>
        /// Reads a <see cref="float" /> from the beginning of a read-only span of bytes, as little endian.
        /// </summary>
        /// <param name="source">The read-only span to read.</param>
        /// <returns>The little endian value.</returns>
        /// <remarks>Reads exactly 4 bytes from the beginning of the span.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="source"/> is too small to contain a <see cref="float" />.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ReadSingleLittleEndian(ReadOnlySpan<byte> source)
        {
            return !BitConverter.IsLittleEndian ?
                BitConverterNetStandard2_0.Int32BitsToSingle(BinaryPrimitives.ReverseEndianness(MemoryMarshal.Read<int>(source))) :
                MemoryMarshal.Read<float>(source);
        }

        /// <summary>
        /// Reads a <see cref="float" /> from the beginning of a read-only span of bytes, as little endian.
        /// </summary>
        /// <param name="source">The read-only span of bytes to read.</param>
        /// <param name="value">When this method returns, the value read out of the read-only span of bytes, as little endian.</param>
        /// <returns>
        /// <see langword="true" /> if the span is large enough to contain a <see cref="float" />; otherwise, <see langword="false" />.
        /// </returns>
        /// <remarks>Reads exactly 4 bytes from the beginning of the span.</remarks>
        public static bool TryReadSingleLittleEndian(ReadOnlySpan<byte> source, out float value)
        {
            if (!BitConverter.IsLittleEndian)
            {
                bool success = MemoryMarshal.TryRead(source, out int tmp);
                value = BitConverterNetStandard2_0.Int32BitsToSingle(BinaryPrimitives.ReverseEndianness(tmp));
                return success;
            }

            return MemoryMarshal.TryRead(source, out value);
        }

        /// <summary>
        /// Reads a <see cref="double" /> from the beginning of a read-only span of bytes, as little endian.
        /// </summary>
        /// <param name="source">The read-only span to read.</param>
        /// <returns>The little endian value.</returns>
        /// <remarks>Reads exactly 8 bytes from the beginning of the span.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="source"/> is too small to contain a <see cref="double" />.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ReadDoubleLittleEndian(ReadOnlySpan<byte> source)
        {
            return !BitConverter.IsLittleEndian ?
                BitConverter.Int64BitsToDouble(BinaryPrimitives.ReverseEndianness(MemoryMarshal.Read<long>(source))) :
                MemoryMarshal.Read<double>(source);
        }

        /// <summary>
        /// Reads a <see cref="double" /> from the beginning of a read-only span of bytes, as little endian.
        /// </summary>
        /// <param name="source">The read-only span of bytes to read.</param>
        /// <param name="value">When this method returns, the value read out of the read-only span of bytes, as little endian.</param>
        /// <returns>
        /// <see langword="true" /> if the span is large enough to contain a <see cref="double" />; otherwise, <see langword="false" />.
        /// </returns>
        /// <remarks>Reads exactly 8 bytes from the beginning of the span.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryReadDoubleLittleEndian(ReadOnlySpan<byte> source, out double value)
        {
            if (!BitConverter.IsLittleEndian)
            {
                bool success = MemoryMarshal.TryRead(source, out long tmp);
                value = BitConverter.Int64BitsToDouble(BinaryPrimitives.ReverseEndianness(tmp));
                return success;
            }

            return MemoryMarshal.TryRead(source, out value);
        }

        /// <summary>
        /// Writes a <see cref="float" /> into a span of bytes, as little endian.
        /// </summary>
        /// <param name="destination">The span of bytes where the value is to be written, as little endian.</param>
        /// <param name="value">The value to write into the span of bytes.</param>
        /// <remarks>Writes exactly 4 bytes to the beginning of the span.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="destination" /> is too small to contain a <see cref="float" />.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteSingleLittleEndian(Span<byte> destination, float value)
        {
            if (!BitConverter.IsLittleEndian)
            {
                int tmp = BinaryPrimitives.ReverseEndianness(BitConverterNetStandard2_0.SingleToInt32Bits(value));
                MemoryMarshal.Write(destination, ref tmp);
            }
            else
            {
                MemoryMarshal.Write(destination, ref value);
            }
        }

        /// <summary>
        /// Writes a <see cref="float" /> into a span of bytes, as little endian.
        /// </summary>
        /// <param name="destination">The span of bytes where the value is to be written, as little endian.</param>
        /// <param name="value">The value to write into the span of bytes.</param>
        /// <returns>
        /// <see langword="true" /> if the span is large enough to contain a <see cref="float" />; otherwise, <see langword="false" />.
        /// </returns>
        /// <remarks>Writes exactly 4 bytes to the beginning of the span.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryWriteSingleLittleEndian(Span<byte> destination, float value)
        {
            if (!BitConverter.IsLittleEndian)
            {
                int tmp = BinaryPrimitives.ReverseEndianness(BitConverterNetStandard2_0.SingleToInt32Bits(value));
                return MemoryMarshal.TryWrite(destination, ref tmp);
            }

            return MemoryMarshal.TryWrite(destination, ref value);
        }

        /// <summary>
        /// Writes a <see cref="double" /> into a span of bytes, as little endian.
        /// </summary>
        /// <param name="destination">The span of bytes where the value is to be written, as little endian.</param>
        /// <param name="value">The value to write into the span of bytes.</param>
        /// <remarks>Writes exactly 8 bytes to the beginning of the span.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="destination" /> is too small to contain a <see cref="double" />.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteDoubleLittleEndian(Span<byte> destination, double value)
        {
            if (!BitConverter.IsLittleEndian)
            {
                long tmp = BinaryPrimitives.ReverseEndianness(BitConverter.DoubleToInt64Bits(value));
                MemoryMarshal.Write(destination, ref tmp);
            }
            else
            {
                MemoryMarshal.Write(destination, ref value);
            }
        }

        /// <summary>
        /// Writes a <see cref="double" /> into a span of bytes, as little endian.
        /// </summary>
        /// <param name="destination">The span of bytes where the value is to be written, as little endian.</param>
        /// <param name="value">The value to write into the span of bytes.</param>
        /// <returns>
        /// <see langword="true" /> if the span is large enough to contain a <see cref="double" />; otherwise, <see langword="false" />.
        /// </returns>
        /// <remarks>Writes exactly 8 bytes to the beginning of the span.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryWriteDoubleLittleEndian(Span<byte> destination, double value)
        {
            if (!BitConverter.IsLittleEndian)
            {
                long tmp = BinaryPrimitives.ReverseEndianness(BitConverter.DoubleToInt64Bits(value));
                return MemoryMarshal.TryWrite(destination, ref tmp);
            }

            return MemoryMarshal.TryWrite(destination, ref value);
        }

        /// <summary>
        /// Reads a <see cref="float" /> from the beginning of a read-only span of bytes, as big endian.
        /// </summary>
        /// <param name="source">The read-only span to read.</param>
        /// <returns>The big endian value.</returns>
        /// <remarks>Reads exactly 4 bytes from the beginning of the span.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="source"/> is too small to contain a <see cref="float" />.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ReadSingleBigEndian(ReadOnlySpan<byte> source)
        {
            return BitConverter.IsLittleEndian ?
                BitConverterNetStandard2_0.Int32BitsToSingle(BinaryPrimitives.ReverseEndianness(MemoryMarshal.Read<int>(source))) :
                MemoryMarshal.Read<float>(source);
        }

        /// <summary>
        /// Reads a <see cref="float" /> from the beginning of a read-only span of bytes, as big endian.
        /// </summary>
        /// <param name="source">The read-only span of bytes to read.</param>
        /// <param name="value">When this method returns, the value read out of the read-only span of bytes, as big endian.</param>
        /// <returns>
        /// <see langword="true" /> if the span is large enough to contain a <see cref="float" />; otherwise, <see langword="false" />.
        /// </returns>
        /// <remarks>Reads exactly 4 bytes from the beginning of the span.</remarks>
        public static bool TryReadSingleBigEndian(ReadOnlySpan<byte> source, out float value)
        {
            if (BitConverter.IsLittleEndian)
            {
                bool success = MemoryMarshal.TryRead(source, out int tmp);
                value = BitConverterNetStandard2_0.Int32BitsToSingle(BinaryPrimitives.ReverseEndianness(tmp));
                return success;
            }

            return MemoryMarshal.TryRead(source, out value);
        }

        /// <summary>
        /// Reads a <see cref="double" /> from the beginning of a read-only span of bytes, as big endian.
        /// </summary>
        /// <param name="source">The read-only span to read.</param>
        /// <returns>The big endian value.</returns>
        /// <remarks>Reads exactly 8 bytes from the beginning of the span.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="source"/> is too small to contain a <see cref="double" />.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ReadDoubleBigEndian(ReadOnlySpan<byte> source)
        {
            return BitConverter.IsLittleEndian ?
                BitConverter.Int64BitsToDouble(BinaryPrimitives.ReverseEndianness(MemoryMarshal.Read<long>(source))) :
                MemoryMarshal.Read<double>(source);
        }

        /// <summary>
        /// Reads a <see cref="double" /> from the beginning of a read-only span of bytes, as big endian.
        /// </summary>
        /// <param name="source">The read-only span of bytes to read.</param>
        /// <param name="value">When this method returns, the value read out of the read-only span of bytes, as big endian.</param>
        /// <returns>
        /// <see langword="true" /> if the span is large enough to contain a <see cref="double" />; otherwise, <see langword="false" />.
        /// </returns>
        /// <remarks>Reads exactly 8 bytes from the beginning of the span.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryReadDoubleBigEndian(ReadOnlySpan<byte> source, out double value)
        {
            if (BitConverter.IsLittleEndian)
            {
                bool success = MemoryMarshal.TryRead(source, out long tmp);
                value = BitConverter.Int64BitsToDouble(BinaryPrimitives.ReverseEndianness(tmp));
                return success;
            }

            return MemoryMarshal.TryRead(source, out value);
        }

        /// <summary>
        /// Writes a <see cref="float" /> into a span of bytes, as big endian.
        /// </summary>
        /// <param name="destination">The span of bytes where the value is to be written, as big endian.</param>
        /// <param name="value">The value to write into the span of bytes.</param>
        /// <remarks>Writes exactly 4 bytes to the beginning of the span.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="destination" /> is too small to contain a <see cref="float" />.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteSingleBigEndian(Span<byte> destination, float value)
        {
            if (BitConverter.IsLittleEndian)
            {
                int tmp = BinaryPrimitives.ReverseEndianness(BitConverterNetStandard2_0.SingleToInt32Bits(value));
                MemoryMarshal.Write(destination, ref tmp);
            }
            else
            {
                MemoryMarshal.Write(destination, ref value);
            }
        }

        /// <summary>
        /// Writes a <see cref="float" /> into a span of bytes, as big endian.
        /// </summary>
        /// <param name="destination">The span of bytes where the value is to be written, as big endian.</param>
        /// <param name="value">The value to write into the span of bytes.</param>
        /// <returns>
        /// <see langword="true" /> if the span is large enough to contain a <see cref="float" />; otherwise, <see langword="false" />.
        /// </returns>
        /// <remarks>Writes exactly 4 bytes to the beginning of the span.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryWriteSingleBigEndian(Span<byte> destination, float value)
        {
            if (BitConverter.IsLittleEndian)
            {
                int tmp = BinaryPrimitives.ReverseEndianness(BitConverterNetStandard2_0.SingleToInt32Bits(value));
                return MemoryMarshal.TryWrite(destination, ref tmp);
            }

            return MemoryMarshal.TryWrite(destination, ref value);
        }

        /// <summary>
        /// Writes a <see cref="double" /> into a span of bytes, as big endian.
        /// </summary>
        /// <param name="destination">The span of bytes where the value is to be written, as big endian.</param>
        /// <param name="value">The value to write into the span of bytes.</param>
        /// <remarks>Writes exactly 8 bytes to the beginning of the span.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="destination" /> is too small to contain a <see cref="double" />.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteDoubleBigEndian(Span<byte> destination, double value)
        {
            if (BitConverter.IsLittleEndian)
            {
                long tmp = BinaryPrimitives.ReverseEndianness(BitConverter.DoubleToInt64Bits(value));
                MemoryMarshal.Write(destination, ref tmp);
            }
            else
            {
                MemoryMarshal.Write(destination, ref value);
            }
        }

        /// <summary>
        /// Writes a <see cref="double" /> into a span of bytes, as big endian.
        /// </summary>
        /// <param name="destination">The span of bytes where the value is to be written, as big endian.</param>
        /// <param name="value">The value to write into the span of bytes.</param>
        /// <returns>
        /// <see langword="true" /> if the span is large enough to contain a <see cref="double" />; otherwise, <see langword="false" />.
        /// </returns>
        /// <remarks>Writes exactly 8 bytes to the beginning of the span.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryWriteDoubleBigEndian(Span<byte> destination, double value)
        {
            if (BitConverter.IsLittleEndian)
            {
                long tmp = BinaryPrimitives.ReverseEndianness(BitConverter.DoubleToInt64Bits(value));
                return MemoryMarshal.TryWrite(destination, ref tmp);
            }

            return MemoryMarshal.TryWrite(destination, ref value);
        }
    }
}
