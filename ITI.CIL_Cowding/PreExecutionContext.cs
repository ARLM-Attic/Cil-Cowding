using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public class PreExecutionContext : IPreExecutionContext
    {
        CILTypeManager _typeManager;
        List<IFunction> _myFunctions;
        List<IError> _errors;
        List<ICILType> _localsVars;
        IFunction _currentFunction;
        int _currentLineInstruction;
        IEngine _engine;

        #region Properties
       
        public List<IError> Errors
        {
            get { return _errors; }
        }

        public List<ICILType> LocalsVar
        {
            get { return _localsVars; }
            set { _localsVars = value; }
        }

        public CILTypeManager TypeManager
        {
            get { return _typeManager; }
        }

        public IFunction CurrentFunction
        {
            get { return _currentFunction; }
        }

        public int CurrentLineInstruction
        {
            get { return _currentLineInstruction; }
        }
        
        #endregion
        public PreExecutionContext(IEngine engine)
        {
            _engine = engine;
            _typeManager = new CILTypeManager();
            _myFunctions = new List<IFunction>();
            _errors = new List<IError>();
          //  _errors = new List<string>();
            _localsVars = new List<ICILType>();
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
                    _currentFunction = function.PreExecute( this );
                    myFunctions.Add( _currentFunction );
                    // Ici on appel le preExecute des functionsNode, du coup le preExecute des nodes, mais le problème c'est que le preExecute des labels necessite la current function. Et donc si on a pas encore créer la function, on ne peut pas avoir de current function. CQFD
                    //myFunctions.Add(function.PreExecute(this));
                }
                else
                {
                        // ON en fait rien, c'est déjà géré dans IsSingleFct
                }
            }

            // Là on a nos fct, donc on le case dans la var
            _myFunctions = myFunctions;

            // on parcourt toutes nos fct et on pré-exécute tous les noeuds
            foreach (Function fct in myFunctions)
            {
                _currentLineInstruction = 0;

                _currentFunction = fct;
                foreach (Node node in fct.Body)
                {
                    if (node is InstructionNode)
                    {
                        node.PreExecute( this );
                    }
                    _currentLineInstruction++;
                }
                
            }

            return myFunctions;
        }

        public Function SearchFunction(string nomFct)
        {
                
            foreach(Function fct in _myFunctions) {
                    
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
            _errors.Add( new SyntaxError( _engine, msg ) );
        }

       

    }

}

