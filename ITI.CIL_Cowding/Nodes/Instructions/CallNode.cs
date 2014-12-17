using System;

namespace ITI.CIL_Cowding
{
    public class CallNode : InstructionNode
    {
        // Fields

        string _label;

        public CallNode(string label)
        {
            _label = label;
        }

        public override void Execute(IExecutionContext ctx)
        {
 	        throw new NotImplementedException();
        }
    }
}
