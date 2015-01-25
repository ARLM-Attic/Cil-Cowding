using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Bitwise complement (logical not).
    /// </summary>
    public class NotNode : InstructionNode
    {
        public NotNode(int line)
            : base( line )
        {
        }
        public override void Execute( IExecutionContext ctx )
        {
            IValue temp = ctx.Stack.Pop();
            if ( temp.Type.IsInt32() && ( (int)temp.Data == 0 || (int)temp.Data == 1 ) )
            {
                if ( !Convert.ToBoolean( temp.Data ) )
                {
                    ctx.Stack.Push( new Value( temp.Type, 1 ) );
                }
                else
                {
                    ctx.Stack.Push( new Value( temp.Type, 0 ) );
                }
            }
            else
            {
                ctx.AddError("Incorrect type on not operator");
            }
        }
    }
}
