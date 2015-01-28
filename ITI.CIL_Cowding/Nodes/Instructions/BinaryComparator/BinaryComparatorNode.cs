using System;

namespace ITI.CIL_Cowding
{
    public abstract class BinaryComparatorNode : InstructionNode
    {
        public abstract IValue Comparator( IValue value1, IValue value2 );
        public sealed override void Execute( IExecutionContext ctx )
        {
            IValue temp = ctx.Stack.Pop();
            IValue temp2 = ctx.Stack.Pop();
            if ( temp.Type.FullName == temp2.Type.FullName && (temp.Type.IsInt32() || temp.Type.IsDouble()) )
            {
                ctx.Stack.Push( this.Comparator( temp2, temp ) );
            }
            else
            {
                ctx.AddError( "Incorrect type on Comparator. Two integers excepted." );
            }
        }
    }
}
