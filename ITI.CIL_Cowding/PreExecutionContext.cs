using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public class PreExecutionContext : IPreExecutionContext
    {
        CILTypeManager _typeManager;
        List<IValue> _localsvar;

        public List<IValue> LocalsVar
        {
            get {return _localsvar;}

            set {
                    if(_localsvar != null)
                    {
                        throw new Exception("Locals Var déjà fait mon gars ...");
                    }
                    else
                    {
                        _localsvar = value;
                    }
                }
        }


        public CILTypeManager TypeManager
        {
            get { return _typeManager; }
        }
        public PreExecutionContext()
        {
            _typeManager = new CILTypeManager();



        }

        public List<Function> PreExecut (List<FunctionNode> code)
        {
            // On parcourt toutes les fct, et on gère plusieurs choses
            foreach(FunctionNode fct in code) {
                // On fait le code de la fct
                fct.PreExecute(this);


            }


            throw new NotImplementedException();
        }

        // ajouter les variables locales et les passer en parametres aux fonctions

    }
}
