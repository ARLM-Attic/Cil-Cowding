using System;
using System.Collections.Generic;
using System.Reflection;

namespace ITI.CIL_Cowding
{
    public class PreExecutionContext : IPreExecutionContext
    {
        CILTypeManager _typeManager;
        List<IFunction> _myFct;
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

            foreach(FunctionNode function in code)
            {
                if (IsSingleFunction(_myFunctions, function))    // On regarde si la fct n'as pas le même nom qu'une autre
                {
                    _currentFunction = function.PreExecute( this );
                    _myFunctions.Add( _currentFunction );
                    // Ici on appel le preExecute des functionsNode, du coup le preExecute des nodes, mais le problème c'est que le preExecute des labels necessite la current function. Et donc si on a pas encore créer la function, on ne peut pas avoir de current function. CQFD
                    //myFunctions.Add(function.PreExecute(this));
                }
                else
                {
                        // ON en fait rien, c'est déjà géré dans IsSingleFct
                }
            }

            // on parcours toutes nos fct et on pré-exécute tous les noeuds
            foreach (Function fct in _myFunctions)
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
            return _myFunctions;
        }

        public FunctionScope SearchFunction(List<string> labels, out Object function)
        {
            // Verif' null toussa magueule

            // We looking for a function at home
            // On ne gère pas les classes internes (pour le moment). VIVE LA FRANCE \o/

            if( labels.Count == 1 ) 
            {
                foreach(Function fct in _myFct) 
                {
                    if(fct.Name == labels[0]) 
                    {
                        function = fct;
                        return FunctionScope.Internal;
                    }
                }
            }
            
            // We looking for a function which is not at home
            string nameType = labels[0];
            
            for(int i = 1; i < labels.Count-1; i++)
            {
                nameType += "." + labels[i];
            }

            Type type = Type.GetType(nameType);
            if (type != null)
            {
                function = type;
                return FunctionScope.External;
            }
            else
            {
                AddError("Function not found.");
                function = null;
                return FunctionScope.None;
            }
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
        
        public void AddError( string msg )
        {
            _errors.Add( new SyntaxError( _engine, msg ) );
        }

       

    }

}

