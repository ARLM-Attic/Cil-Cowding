using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public class LabelNode : InstructionNode
    {
        string _label;
        public LabelNode(string label)
        {
            _label = label;
        }
        public override void Execute( IExecutionContext ctx )
        {
            // RIEN
        }
        public override void PreExecute(IPreExecutionContext pec)
        {
            pec.CurrentFunction.AddLabel(_label, pec.CurrentLineInstruction);
            
        }
    }
}
