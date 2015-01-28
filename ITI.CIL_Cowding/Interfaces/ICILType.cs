using System;

namespace ITI.CIL_Cowding
{
    public interface ICILType
    {
        string FullName { get; }

        /// <summary>
        /// Gets whether this type suports Addition Subtraction Multiplication  and Division
        /// </summary>
        bool IsNumeric { get; }

        bool IsNetType { get; }
        Type RealType { get; }

        /// <summary>
        /// Gets the actual .net type: null if <see cref="IsNetType"/> is false.
        /// </summary>
        Type NetType { get; }

        bool IsValueType { get; }

        /// <summary>
        /// Gets the size of this type in Bytes on the stack (4 for reference types).
        /// </summary>
        int StackSize { get; }
        bool IsBool();
        bool IsInt32();
        bool IsInt64();
        bool IsInt16();
        bool IsUInt32();
        bool IsUInt16();
        bool IsUInt64();
        bool IsSByte();
        bool IsByte();
        bool IsFloat();
        bool IsDouble();
        bool IsDecimal();
        bool IsChar();
        bool IsDateTime();
        bool IsString();
    }
}
