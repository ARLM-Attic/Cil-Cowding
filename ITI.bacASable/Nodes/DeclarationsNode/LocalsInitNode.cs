using System;
using System.Collections.Generic;

namespace ITI.bacASable
{
    public class LocalsInitNode : DeclarationNode
    {
        List<string> _stringTypes;
      public LocalsInitNode(List<string> stringTypes, int line)
            : base( line )
        {
            _stringTypes = stringTypes;           
        }
        public override void PreExecute(IPreExecutionContext pec)
        {
            foreach (string stringType in _stringTypes)
            {
                pec.AddLocalVariable( pec.TypeManager.Find( stringType ) );
            }
        }
    }
}
