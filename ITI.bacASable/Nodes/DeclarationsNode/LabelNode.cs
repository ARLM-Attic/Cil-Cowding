using System;
using System.Collections.Generic;

namespace ITI.bacASable

{
    public class LabelNode : DeclarationNode
    {
        readonly string _label;
        int _instructionLineNumber;

        public LabelNode( string label, int line )
            : base( line )
        {
            _label = label;
        }

        public string Name
        {
            get { return _label; }
        }

        public int InstructionLineNumber
        {
            get { return _instructionLineNumber; }
        }
        
        public override void PreExecute( IPreExecutionContext pec )
        {
            if (pec.CurrentLineInstruction == 1)
            {
                _instructionLineNumber = 0;
            }
            else
            {
                _instructionLineNumber = pec.CurrentLineInstruction - 1;
            }
            
            if (!pec.AddLabel( this ))
            {
                throw new NotImplementedException( "TODO : Error on label pre execute" );
            }
        }
    }
}
