using System;
using System.Collections.Generic;

namespace ITI.bacASable

{
    public class LabelNode : DeclarationNode
    {
        string _label;
        public LabelNode( string label, int line )
            : base( line )
        {
            _label = label;
        }
        public override void PreExecute( PreExecutionContext pec )
        {
          //  pec.CurrentFunction.AddLabel( _label, pec.CurrentLineInstruction );
        }
    }
}
