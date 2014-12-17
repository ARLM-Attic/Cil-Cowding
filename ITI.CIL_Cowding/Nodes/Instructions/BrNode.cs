using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Branch to target.
    /// </summary>
    public class BrNode : InstructionNode
    {
        string _label;

        public BrNode(string label)
        {
            _label = label;
        }

        public override void Execute(IExecutionContext ctx)
        {
            throw new NotImplementedException();
        }
    }
}
