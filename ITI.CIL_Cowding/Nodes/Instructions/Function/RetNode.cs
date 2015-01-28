using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Return from method, possibly with a value.
    /// </summary>
    class RetNode : InstructionNode
    {
        int _line;
        public override int Line
        {
            get { return _line; }
        }
        public RetNode(int line)
        {
            _line = line;
        }
        public override void Execute(IExecutionContext ctx)
        {
            ctx.Stack.CloseFunction();
        }
    }
}
