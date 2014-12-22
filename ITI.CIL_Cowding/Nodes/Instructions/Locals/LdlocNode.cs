using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Load local variable of specified index onto stack.
    /// </summary>
    public class LdlocNode : InstructionNode
    {


        private int _index;
        public LdlocNode( int index )
        {
            _index = index;
        }
        public override void Execute( IExecutionContext ctx )
        {
            ctx.Stack.Push( ctx.Stack.GetLocalVar( _index ) );
        }
    }
}
