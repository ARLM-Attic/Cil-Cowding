using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Branch to target.
    /// </summary>
    public class BrNode : InstructionNode
    {
        string _label;
        int _line;
        public override int Line
        {
            get { return _line; }
        }
        public BrNode(string label, int line)
        {
            _label = label;
            _line = line;
        }

        public override void Execute(IExecutionContext ctx)
        {
            int index = ctx.Stack.LastFrame.Fct.GetIndexLabel(_label);
            ctx.Stack.LastFrame.SetCurrentInstruction(index);
        }
    }
}
