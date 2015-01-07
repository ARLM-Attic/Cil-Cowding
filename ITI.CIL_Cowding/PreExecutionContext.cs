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
        List<ICILType> _locvar;
        Function _currentfct;
        int _lineInstruction;
        IEngine _engine;

        #region Properties
       
        public List<IError> Errors
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
        public PreExecutionContext(IEngine engine)
        {
            _engine = engine;
            _typeManager = new CILTypeManager();
            _myFct = new List<IFunction>();
            _errors = new List<IError>();
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
            _myFct = myFunctions;

            // on parcourt toutes nos fct et on pré-exécute tous les noeuds
            foreach (Function fct in myFunctions)
            {
                _lineInstruction = 0;

                _currentfct = fct;
                foreach (InstructionNode IN in fct.Code)
                {
                    if(IN is LocalsInitNode) {
                    }
                    else
                    {
                        IN.PreExecute(this);
                    }
                    _lineInstruction++;
                }
            }
            return myFunctions;
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
            string nameType = "";
            for(int i = 0; i < labels.Count-2; i++)
            {
                nameType += labels[i];
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

