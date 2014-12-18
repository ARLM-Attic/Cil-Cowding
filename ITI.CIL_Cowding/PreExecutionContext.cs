using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public class PreExecutionContext : IPreExecutionContext
    {
        CILTypeManager _typeManager;
        List<ICILType> _localsVar;
        List<SyntaxError> _errors;
        Dictionary<string, int> _labels;

        #region Properties
        public Dictionary<string,int> Labels
        {
            get { return _labels; }
        }
        public List<SyntaxError> Errors
        {
            get { return _errors; }
        }

        /// <summary>
        /// Get or Set locals variables in the current context.
        /// </summary>
        public List<ICILType> LocalsVar
        {
            get {return _localsVar;}

            set {
                        _localsVar = value;   
                }
        }


        public CILTypeManager TypeManager
        {
            get { return _typeManager; }
        }
        #endregion
        public PreExecutionContext()
        {
            _typeManager = new CILTypeManager();
            _localsVar = new List<ICILType>();
            _errors = new List<SyntaxError>();
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

            return myFunctions;
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

        public void AddLabel(KeyValuePair<string,int> label)
        {
            _labels.Add( label.Key, label.Value );
        }
    }
}






















// Moi j'aime bien tout ce qui est exellent !