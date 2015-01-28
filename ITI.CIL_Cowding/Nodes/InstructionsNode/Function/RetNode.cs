using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Return from method, possibly with a value.
    /// </summary>
    class RetNode : InstructionNode
    {
        public RetNode( int line )
            : base( line )
        {
        }

        public override void Execute(IExecutionContext ctx)
        {
            ctx.Stack.CloseFunction();
        }
    }
}
