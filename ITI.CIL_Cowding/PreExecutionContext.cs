using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public class PreExecutionContext : IPreExecutionContext
    {
        CILTypeManager _typeManager;
        List<IFunction> _mes_fct;
        List<SyntaxError> _errors;
        Dictionary<string, int> _labels;
        //List<string> _errors;
        List<ICILType> _locvar;

        #region Properties
        public Dictionary<string,int> Labels
        {
            get { return _labels; }
        }
        public List<SyntaxError> Errors
        {
            get { return _errors; }
        }

        public List<ICILType> LocalsVar
        {
            get { return _locvar; }
            set { _locvar = value; }
        }

        public CILTypeManager TypeManager
        {
            get { return _typeManager; }
        }
        #endregion
        public PreExecutionContext()
        {
            _typeManager = new CILTypeManager();
            _mes_fct = new List<IFunction>();
            _errors = new List<SyntaxError>();
          //  _errors = new List<string>();
            _locvar = new List<ICILType>();
        }

        /// <summary>
        /// Create all functions from functionNode.
        /// </summary>
        /// <param name="code">All the source code, therefore the list of function node.</param>
        /// <returns>List of functions ready to execute.</returns>
        public List<IFunction> PreExecut (List<FunctionNode> code)
        {
            List<IFunction> myFunctions = new List<IFunction>();

            foreach(FunctionNode function in code)
            {
                if ( IsSingleFunction(myFunctions, function) )
                {
                    myFunctions.Add( function.PreExecute( this ) );
                }
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

       /* public void AddError(string msg)
        {
            _errors.Add(msg);
        }
        */
        private bool IsSingleFunction (List<IFunction> myFunctions, FunctionNode function)
        {
            foreach ( IFunction functionForName in myFunctions )
            {
                if ( functionForName.Name == function.Name )
                {
                    AddError( "Function " + function.Name + " already exist" );
                    return false;
                }
            }
            return true;
            
        }
        private void AddError( string msg )
        {
            _errors.Add( new SyntaxError( msg ) );
        }
        
        public void AddLabel(KeyValuePair<string,int> label)
        {
            _labels.Add( label.Key, label.Value );
        }
    }
}






















// Moi j'aime bien tout ce qui est exellent !