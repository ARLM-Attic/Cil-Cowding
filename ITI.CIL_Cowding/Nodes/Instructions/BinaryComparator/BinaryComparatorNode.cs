using System;

namespace ITI.CIL_Cowding
{
    public abstract class BinaryComparatorNode : InstructionNode
    {
        protected abstract IValue Comparator( IValue value1, IValue value2 );
        public sealed override void Execute( IExecutionContext ctx )
        {
            IValue temp = ctx.Stack.Pop();
            IValue temp2 = ctx.Stack.Pop();
            if ( temp.Type == temp2.Type && temp.Type.IsInt32() )
            {
                ctx.Stack.Push( this.Comparator( temp2, temp ) );
            }
        }
    }
}
