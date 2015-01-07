using System;
using System.Collections.Generic;
using System.Reflection;

namespace ITI.CIL_Cowding
{
    public class CILNetType : ICILType
    {
        readonly Type _type;
        readonly int _size;

        public CILNetType( Type netType )
        {
            _size = StackSizeOf( netType );
            _type = netType;
        }

        public Type RealType
        {
            get { return _type; }
        }
        public bool IsNumeric
        {
            get 
            {
                switch ( Type.GetTypeCode( _type ) )
                {
                    case TypeCode.Byte:
                    case TypeCode.Decimal:
                    case TypeCode.Double:
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                    case TypeCode.SByte:
                    case TypeCode.Single:
                    case TypeCode.UInt16:
                    case TypeCode.UInt32:
                    case TypeCode.UInt64:
                        return true;
                    default:
                        return false;
                }
            }
        }
        #region IsThatType
        public bool IsBool()
        {
            return Type.GetTypeCode( this._type ) == TypeCode.Boolean;
        }
        public bool IsInt32()
        {
            return Type.GetTypeCode( this._type ) == TypeCode.Int32;
        }
        public bool IsInt16()
        {
            return Type.GetTypeCode( this._type ) == TypeCode.Int16;
        }
        public bool IsInt64()
        {
            return Type.GetTypeCode( this._type ) == TypeCode.Int64;
        }
        public bool IsUInt32()
        {
            return Type.GetTypeCode( this._type ) == TypeCode.UInt32;
        }
        public bool IsUInt16()
        {
            return Type.GetTypeCode( this._type ) == TypeCode.UInt16;
        }
        public bool IsUInt64()
        {
            return Type.GetTypeCode( this._type ) == TypeCode.UInt64;
        }
        public bool IsChar()
        {
            return Type.GetTypeCode( this._type ) == TypeCode.Char;
        }
        public bool IsSByte()
        {
            return Type.GetTypeCode( this._type ) == TypeCode.SByte;
        }
        public bool IsByte()
        {
            return Type.GetTypeCode( this._type ) == TypeCode.Byte;
        }
        public bool IsDouble()
        {
            return Type.GetTypeCode( this._type ) == TypeCode.Double;
        }
        public bool IsFloat()
        {
            return Type.GetTypeCode( this._type ) == TypeCode.Single;
        }
        public bool IsDecimal()
        {
            return Type.GetTypeCode( this._type ) == TypeCode.Decimal;
        }
        public bool IsDateTime()
        {
            return Type.GetTypeCode( this._type ) == TypeCode.DateTime;
        }
        public bool IsString()
        {
            return Type.GetTypeCode( this._type ) == TypeCode.String;
        }
        #endregion
        static int StackSizeOf( Type t )
        {
            if ( !t.IsValueType ) return 4;
            if ( t == typeof( Int32 ) || t == typeof( UInt32 ) ) return 4;
            if ( t == typeof( Int64 ) || t == typeof( UInt64 ) ) return 8;
            if ( t == typeof( Int16 ) || t == typeof( UInt16 ) ) return 2;
            if ( t == typeof( SByte ) || t == typeof( Byte ) ) return 1;
            if ( t == typeof( Boolean ) ) return 1;
            if ( t == typeof( Single ) ) return 4;
            if ( t == typeof( Double ) ) return 8;
            if ( t == typeof( Char ) ) return 2;
            if ( t == typeof( DateTime ) ) return 8;
            if ( t == typeof( Guid ) ) return 16;
            FieldInfo[] fields = t.GetFields( BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public );
            int size = 0;
            foreach (FieldInfo f in fields)
            {
                size += StackSizeOf( f.FieldType );
            }
            return size;
        }

        public int StackSize
        {
            get { return _size; }
        }
        public string FullName
        {
            get { return _type.FullName; }
        }
        public bool IsNetType
        { 
            get { return true; } 
        }
        public Type NetType
        {
            get { return _type; } 
        }
        public bool IsValueType
        {
            get { return _type.IsValueType; }
        }
    }
}
