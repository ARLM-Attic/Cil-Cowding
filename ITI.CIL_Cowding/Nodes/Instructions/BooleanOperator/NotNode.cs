using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Bitwise complement (logical not).
    /// </summary>
    public class NotNode : InstructionNode
    {
        public override void Execute( IExecutionContext ctx )
        {
            IValue temp = ctx.Stack.Pop();
            if ( temp.Type.IsBool() )
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
        }
    }
}
