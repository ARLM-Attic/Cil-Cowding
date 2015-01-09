using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Pop a value from stack into local variable.
    /// </summary>
    public class StlocNode : InstructionNode
    {
        int _line;
        public override int Line
        {
            get { return _line; }
        }
        private int _index;
        public StlocNode( int index, int line )
        {
            _index = index;
            _line = line;
        }
        public override void Execute( IExecutionContext ctx )
        {
            ctx.Stack.SetLocalVar( ctx.Stack.Pop(), _index );
        }
    }
}
