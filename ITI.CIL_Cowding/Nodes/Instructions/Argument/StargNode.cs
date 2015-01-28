using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Pop a value from stack into local variable.
    /// </summary>
    public class StargNode : InstructionNode
    {
        int _line;
        private int _index;
        public override int Line
        {
            get { return _line; }
        }
        public StargNode( int index, int line )
        {
            _index = index;
            _line = line;
        }
        public override void Execute( IExecutionContext ctx )
        {
            ctx.Stack.SetArgVar(_index, ctx.Stack.Pop());
        }
    }
}
