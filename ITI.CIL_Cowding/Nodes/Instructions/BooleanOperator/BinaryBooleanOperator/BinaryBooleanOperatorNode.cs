using System;

namespace ITI.CIL_Cowding
{
    public abstract class BinaryBooleanOperatorNode : InstructionNode
    {
        protected abstract IValue Operator( IValue value1, IValue value2 );
        public sealed override void Execute( IExecutionContext ctx )
        {
            IValue temp = ctx.Stack.Pop();
            IValue temp2 = ctx.Stack.Pop();
            if ( temp.Type.FullName == temp2.Type.FullName )
            {
                ctx.Stack.Push( this.Operator( temp2, temp ) );
            }
        }
    }
}
