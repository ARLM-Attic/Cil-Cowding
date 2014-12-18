using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public class LabelNode : InstructionNode
    {
        KeyValuePair <string,int> _label;
        public LabelNode(KeyValuePair <string,int> label)
        {
            _label = label;
        }
        public override void Execute( IExecutionContext ctx )
        {
            throw new NotImplementedException();
        }
        public void PreExecute(IPreExecutionContext pec)
        {
            pec.AddLabel( _label );
            
        }
    }
}
