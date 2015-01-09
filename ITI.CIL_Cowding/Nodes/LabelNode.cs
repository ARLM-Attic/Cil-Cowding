using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public class LabelNode : DeclarationNode
    {
        string _label;
       public LabelNode(string label, int line)
            : base( line )
        {
            _label = label;
        }
        public override void PreExecute(IPreExecutionContext pec)
        {
            pec.CurrentFunction.AddLabel(_label, pec.CurrentLineInstruction);
            
        }
    }
}
