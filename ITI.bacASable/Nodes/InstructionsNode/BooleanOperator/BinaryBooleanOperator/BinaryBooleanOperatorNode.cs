using System;

namespace ITI.bacASable
{
    public abstract class BinaryBooleanOperatorNode : InstructionNode
    {
        public BinaryBooleanOperatorNode (int line)
        : base( line )
        { }
        protected abstract IValue Operator( IValue value1, IValue value2 );
        public sealed override void Execute( IExecutionContext ctx )
        {
            IValue temp = ctx.Stack.Pop();
            IValue temp2 = ctx.Stack.Pop();
            if ( temp.Type.FullName == temp2.Type.FullName && ( (int)temp.Data == 0 || (int)temp.Data == 1 ) && ( (int)temp2.Data == 0 || (int)temp2.Data == 1 ) )
            {
                ctx.Stack.Push( this.Operator( temp2, temp ) );
            }
            else
            {
                ctx.AddError("Incorrect type on Binary Boolean Operator. Two booleans excepted.");
            }
        }
    }
}
