using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Load local variable of specified index onto stack.
    /// </summary>
    public class LdlocNode : InstructionNode
    {


        private int _index;
        int _line;
        public override int Line
        {
            get { return _line; }
        }
        public LdlocNode( int index, int line )
        {
            _index = index;
            _line = line;
        }
        public override void Execute( IExecutionContext ctx )
        {
            ctx.Stack.Push( ctx.Stack.GetLocalVar( _index ) );
        }
    }
}
