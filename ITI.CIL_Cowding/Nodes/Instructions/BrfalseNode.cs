using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Branch to target if value is zero (false).
    /// </summary>
    public class BrfalseNode : InstructionNode
    {
        string _label;

        public BrfalseNode(string label)
        {
            _label = label;
        }

        public override void Execute(IExecutionContext ctx)
        {
            throw new NotImplementedException();
        }
    }
}
