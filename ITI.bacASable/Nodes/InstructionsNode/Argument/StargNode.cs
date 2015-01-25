using System;

namespace ITI.bacASable
{
    /// <summary>
    /// Pop a value from stack into local variable.
    /// </summary>
    public class StargNode : InstructionNode
    {
        private int _index;
      
        public StargNode( int index, int line )
            : base( line )
        {
            _index = index;
        }
        public override void Execute( IExecutionContext ctx )
        {
            ctx.Stack.SetArgVar(_index, ctx.Stack.Pop());
        }
    }
}
