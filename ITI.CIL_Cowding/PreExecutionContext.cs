using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public class PreExecutionContext : IPreExecutionContext
    {
        CILTypeManager _typeManager;
        List<Function> _mes_fct;
        List<string> _errors;
        List<ICILType> _locvar;

        public List<ICILType> LocalsVar
        {
            get { return _locvar; }
            set { _locvar = value; }
        }

        public CILTypeManager TypeManager
        {
            get { return _typeManager; }
        }
        public PreExecutionContext()
        {
            _typeManager = new CILTypeManager();
            _mes_fct = new List<Function>();
            _errors = new List<string>();
            _locvar = new List<ICILType>();
        }

        /// <summary>
        /// Create all functions from functionNode.
        /// </summary>
        /// <param name="code">All the source code, therefore the list of function node.</param>
        /// <returns>List of functions ready to execute.</returns>
        public List<Function> PreExecut (List<FunctionNode> code)
        {
            List<Function> myFunctions = new List<Function>();

            foreach(FunctionNode function in code) 
            {
                myFunctions.Add( function.PreExecute(this) );
            }

            // Là on a nos fct, donc on le case dans la var
            _mes_fct = myFunctions;

            // on parcourt toutes nos fct et on pré-exécute tous les noeuds
            foreach (Function fct in myFunctions)
            {
                foreach (InstructionNode IN in fct.Code)
                {
                    IN.PreExecute(this);
                }
                
            }

            return myFunctions;
        }

        public Function SearchFunction(string nomFct)
        {
                
            foreach(Function fct in _mes_fct) {
                    
                if(fct.Name == nomFct) {
                    return fct;
                }

            }

            AddError("Function not found.");
            return null;
        }

        public void AddError(string msg)
        {
            _errors.Add(msg);
        }


    }
}
