using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public class PreExecutionContext
    {
        CILTypeManager _typeManager;

        public CILTypeManager TypeManager
        {
            get { return _typeManager; }
        }
        public PreExecutionContext()
        {
            _typeManager = new CILTypeManager();
        }

        // ajouter les variables locales et les passer en parametres aux fonctions

    }
}
