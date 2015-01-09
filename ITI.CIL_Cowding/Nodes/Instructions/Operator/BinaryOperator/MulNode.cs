using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Multiply values
    /// </summary>
    public class MulNode : BinaryOperatorNode
    {
        protected override IValue Operator( IValue value1, IValue value2 )
        {
            {
                #region Switch
                switch ( Type.GetTypeCode( value1.Type.NetType ) )
                {
                    case TypeCode.Byte:
                        return ( new Value( value1.Type, (byte)value1.Data * (byte)value2.Data ) );
                    case TypeCode.Decimal:
                        return ( new Value( value1.Type, (Decimal)value1.Data * (Decimal)value2.Data ) );
                    case TypeCode.Double:
                        return ( new Value( value1.Type, (Double)value1.Data * (Double)value2.Data ) );
                    case TypeCode.Int16:
                        return ( new Value( value1.Type, (Int16)value1.Data * (Int16)value2.Data ) );
                    case TypeCode.Int32:
                        return ( new Value( value1.Type, (Int32)value1.Data * (Int32)value2.Data ) );
                    case TypeCode.Int64:
                        return ( new Value( value1.Type, (Int64)value1.Data * (Int64)value2.Data ) );
                    case TypeCode.SByte:
                        return ( new Value( value1.Type, (SByte)value1.Data * (SByte)value2.Data ) );
                    case TypeCode.Single:
                        return ( new Value( value1.Type, (Single)value1.Data * (Single)value2.Data ) );
                    case TypeCode.UInt16:
                        return ( new Value( value1.Type, (UInt16)value1.Data * (UInt16)value2.Data ) );
                    case TypeCode.UInt32:
                        return ( new Value( value1.Type, (UInt32)value1.Data * (UInt32)value2.Data ) );
                    case TypeCode.UInt64:
                        return ( new Value( value1.Type, (UInt64)value1.Data * (UInt64)value2.Data ) );
                    default:
                        return ( new Value( null, null ) );
                }
                #endregion    
            }
        }
    }
}
