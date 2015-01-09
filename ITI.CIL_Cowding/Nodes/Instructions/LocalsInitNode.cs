using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public class LocalsInitNode : InstructionNode
    {
        List<ICILType> _localsVars;
        List<string> _types;
        int _line;
        public override int Line
        {
            get { return _line; }
        }

        public LocalsInitNode(List<string> types, int line)
        {
            _types = types;
            _line = line;
            _localsVars = new List<ICILType>();
           
        }
        public override void PreExecute(IPreExecutionContext pec)
        {
            // on créer des values à profusion
            foreach (string str in _types)
            {
                _localsVars.Add( pec.TypeManager.Find( str ) );
            }

            pec.LocalsVar = _localsVars;

        }
        public override void Execute(IExecutionContext ctx)
        {
            // ON NE FAIT RIEN
        }
        
    }
}
