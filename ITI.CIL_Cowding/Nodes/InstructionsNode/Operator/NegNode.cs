using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Negate value.
    /// </summary>
    public class NegNode : InstructionNode
    {
       public NegNode(int line)
            : base( line )
        {
        }
        public override void Execute( IExecutionContext ctx )
        {
            IValue temp = ctx.Stack.Pop();
            if ( temp.Type.IsNumeric )
            {
                #region Switch
                switch ( Type.GetTypeCode( temp.Type.NetType ) )
                {
                    case TypeCode.SByte:
                        ctx.Stack.Push( new Value( temp.Type, -(sbyte)temp.Data ) );
                        break;
                    case TypeCode.Byte:
                        ctx.Stack.Push( new Value( temp.Type, -(byte)temp.Data ) );
                        break;
                    case TypeCode.Int16:
                        ctx.Stack.Push( new Value( temp.Type, -(short)temp.Data ) );
                        break;
                    case TypeCode.UInt16:
                        ctx.Stack.Push( new Value( temp.Type, -(ushort)temp.Data ) );
                        break;
                    case TypeCode.Int32:
                        ctx.Stack.Push( new Value( temp.Type, -(int)temp.Data ) );
                        break;
                    case TypeCode.UInt32:
                        ctx.Stack.Push( new Value( temp.Type, -(uint)temp.Data ) );
                        break;
                    case TypeCode.Int64:
                        ctx.Stack.Push( new Value( temp.Type, -(long)temp.Data ) );
                        break;
                    case TypeCode.UInt64:
                        //ctx.Stack.Push( new Value( temp.Type, -(ulong)temp.Data ) );
                        break;
                    case TypeCode.Single:
                        ctx.Stack.Push( new Value( temp.Type, -(float)temp.Data ) );
                        break;
                    case TypeCode.Double:
                        ctx.Stack.Push( new Value( temp.Type, -(double)temp.Data ) );
                        break;
                    case TypeCode.Decimal:
                        ctx.Stack.Push( new Value( temp.Type, -(decimal)temp.Data ) );
                        break;
                    default:
                        ctx.Stack.Push( new Value( null, null ) );
                        break;
                }
                #endregion
            }
            else
            {
                ctx.AddError("Cannot negate non numeric value.");
            }
        }
    }
}
