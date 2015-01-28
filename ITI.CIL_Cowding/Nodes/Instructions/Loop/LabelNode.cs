using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public class LabelNode : InstructionNode
    {
        string _label;
        int _line;
        public override int Line
        {
            get { return _line; }
        }
        public LabelNode(string label, int line)
        {
            _label = label;
            _line = line;
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
