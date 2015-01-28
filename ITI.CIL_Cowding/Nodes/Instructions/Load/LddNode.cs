using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Push num of type int32 onto the stack as int32.
    /// </summary>
    public class LddNode : InstructionNode
    {
        private double _val;
        int _line;
        public override int Line
        {
            get { return _line; }
        }
        public LddNode(double val, int line)
        {
            this._val = val;
            _line = line;
        }
        public override void Execute(IExecutionContext ctx)
        {
            ctx.Stack.Push(new Value(new CILNetType(typeof(double)), this._val));
        }
    }
}
