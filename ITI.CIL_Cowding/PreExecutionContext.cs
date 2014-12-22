using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public class PreExecutionContext : IPreExecutionContext
    {
        CILTypeManager _typeManager;
        List<IFunction> _mes_fct;
        List<SyntaxError> _errors;
        List<ICILType> _locvar;
        Function _currentfct;
        int _lineInstruction;

        #region Properties
       
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

        public Function CurrentFunction
        {
            get { return _currentfct; }
        }

        public int CurrentLineInstruction
        {
            get { return _lineInstruction; }
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
                if (IsSingleFunction(myFunctions, function))    // On regarde si la fct n'as pas le même nom qu'une autre
                {
                    myFunctions.Add(function.PreExecute(this));
                }
                else
                {
                        // ON en fait rien, c'est déjà géré dans IsSingleFct
                }
            }

            // Là on a nos fct, donc on le case dans la var
            _mes_fct = myFunctions;

            // on parcourt toutes nos fct et on pré-exécute tous les noeuds
            foreach (Function fct in myFunctions)
            {
                _lineInstruction = 0;

                _currentfct = fct;
                foreach (InstructionNode IN in fct.Code)
                {
                    IN.PreExecute(this);
                    _lineInstruction++;
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

       

    }

}

