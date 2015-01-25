using System;
using System.Collections.Generic;
namespace ITI.bacASable
{
    public interface IPreExecutionContext
    {
        CILTypeManager TypeManager { get; }

        bool AddInstructionNodeToCurrentFunction( InstructionNode instruction );

        bool AddLabel( LabelNode label );

        bool AddNewFunctionToCurrentClass( string name, ICILType returnType, List<ICILType> parameters );

        int CurrentLineInstruction { get; }

        IFunction EndCurrentFunction();

        bool IsInFunction { get; }
    }
}
