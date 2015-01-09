using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public class LocalsInitNode : DeclarationNode
    {
        List<ICILType> _localsVars;
        List<string> _types;
      public LocalsInitNode(List<string> types, int line)
            : base( line )
        {
            _types = types;
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
    }
}
