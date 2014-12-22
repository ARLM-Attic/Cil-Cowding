using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Pop a value from stack into local variable.
    /// </summary>
    public class StargNode : InstructionNode
    {
       
        private int _index;
        public StargNode( int index )
        {
            _index = index;
        }
        public override void Execute( IExecutionContext ctx )
        {
            ctx.Stack.SetArgVar(_index, ctx.Stack.Pop());
        }
    }
}
