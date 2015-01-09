using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Branch to target.
    /// </summary>
    public class BrNode : InstructionNode
    {
        string _label;
       public BrNode(string label, int line)
            : base( line )
        {
            _label = label;
        }

        public override void Execute(IExecutionContext ctx)
        {
            int index = ctx.Stack.LastFrame.Fct.GetIndexLabel(_label);
            ctx.Stack.LastFrame.SetCurrentInstruction(index);
        }
    }
}
