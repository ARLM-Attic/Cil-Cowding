using System;
using System.Collections.Generic;
using System.Reflection;

namespace ITI.bacASable
{
    public class PreExecutionContext : ITI.bacASable.IPreExecutionContext
    {
        readonly CILTypeManager _typeManager;

        Dictionary<string, CILClass> _currentProgramClasses;

        string _currentClassName;
        Dictionary<string,IFunction> _currentClassFunctions;

        string _currentFunctionName;
        List<LabelNode> _currentFunctionLabels;
        List<InstructionNode> _currentFunctionBody;
        ICILType _currentFunctionReturnType;
        List<ICILType> _currentFunctionParameters;
        List<ICILType> _currentFunctionLocalsVariables;


      
        public PreExecutionContext( CILTypeManager typeManager )
        {
           _typeManager = typeManager;
           _currentProgramClasses = new Dictionary<string,CILClass>();
        }

        #region Properties
        public CILTypeManager TypeManager
        {
            get { return _typeManager; }
        }
        public bool IsInClass
        {
            get { return _currentClassFunctions != null; }
        }

        public bool IsInFunction
        {
            get { return _currentFunctionBody != null; }
        }

        public int CurrentLineInstruction
        {
            get { return _currentFunctionBody.Count; }
        }
        #endregion

        public bool AddNewClass( string className )
        {
            _currentClassName = className;
            _currentClassFunctions = new Dictionary<string, IFunction>();
            return true;
        }

        public CILClass EndNewClass()
        {
            var c = new CILClass( _currentClassFunctions );
            _currentProgramClasses.Add( _currentClassName, c );
            _currentClassFunctions = null;
            return c;
        }

        public CILProgram GetFinalProgram()
        {
            var p = new CILProgram( _currentProgramClasses );
            return p;
        }

        public bool AddLocalVariable(ICILType localVariable)
        {
            if (!_currentFunctionLocalsVariables.Contains(localVariable))
            {
                _currentFunctionLocalsVariables.Add( localVariable );
                return true;
            } 
            return false;
        }

        public bool AddLabel(LabelNode label)
        {
            if ( !_currentFunctionLabels.Contains( label ) )
            {
                _currentFunctionLabels.Add( label );
                return true;
            }
            return false;            
        }

        public bool AddNewFunctionToCurrentClass( string name, ICILType returnType, List<ICILType> parameters)
        {
            if ( IsInClass && !IsInFunction && !_currentClassFunctions.ContainsKey( name ) ) 
            {
                _currentFunctionName = name;
                _currentFunctionReturnType = returnType;
                _currentFunctionParameters = parameters;

                _currentFunctionBody = new List<InstructionNode>();
                _currentFunctionLabels = new List<LabelNode>();
                _currentFunctionLocalsVariables = new List<ICILType>();

                return true;
            }
            return false;
        }

        public bool AddInstructionNodeToCurrentFunction( InstructionNode instruction )
        {
            _currentFunctionBody.Add( instruction );
            return true;
        }

        public IFunction EndCurrentFunction()
        {
            IFunction function = new Function( _currentFunctionName, _currentFunctionReturnType, _currentFunctionParameters, _currentFunctionLocalsVariables, _currentFunctionBody );

            _currentClassFunctions.Add( _currentFunctionName, function );

            _currentFunctionName = null;
            _currentFunctionBody = null;
            _currentFunctionLabels = null;
            _currentFunctionBody = null;
            _currentFunctionReturnType = null;
            _currentFunctionParameters = null;
            _currentFunctionLocalsVariables = null;

            return function;
        }
    }

}

