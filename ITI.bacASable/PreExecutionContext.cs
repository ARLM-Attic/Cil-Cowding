using System;
using System.Collections.Generic;
using System.Reflection;

namespace ITI.bacASable
{
    public class PreExecutionContext
    {
        List<InstructionNode> _currentFunctionBody;
        Dictionary<string, List<InstructionNode>> _currentClassFunctionBodies;
      

        public bool IsInFunction
        {
            get { return _currentFunctionBody != null; }
        }

        public int CurrentLineInstruction
        {
            get { return _currentFunctionBody.Count; }
        }

        public PreExecutionContext( )
        {
           _currentClassFunctionBodies = new Dictionary<string, List<InstructionNode>>();
        }

        bool AddNewFunctionToCurrentClass( string name )
        {
            if ( !_currentClassFunctionBodies.ContainsKey( name ) ) 
            {
                _currentFunctionBody = new List<InstructionNode>();
                _currentClassFunctionBodies.Add( name, _currentFunctionBody );
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddInstructionNodeToCurrentFunction( InstructionNode instruction )
        {
            _currentFunctionBody.Add( instruction );
            return true;
        }

        public List<InstructionNode> EndCurrentFunctionAndGetBody()
        {
            var body = _currentFunctionBody;
            _currentFunctionBody = null;
            return body;
        }


    }

}

