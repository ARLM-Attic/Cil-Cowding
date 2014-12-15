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
        List<IValue> _localsVar;

        public List<IValue> LocalsVar
        {
            get {return _localsVar;}

            set {
                    if(_localsVar != null)
                    {
                        throw new Exception("Locals Var déjà fait mon gars ...");
                    }
                    else
                    {
                        _localsVar = value;
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
            List<Function> myFunctions = new List<Function>();

            // On parcourt toutes les fct, et on gère plusieurs choses
            foreach(FunctionNode fct in code) {
                // On fait le code de la fct
                myFunctions.Add( fct.PreExecute(this) );
            }

            return myFunctions;
        }


    }
}
