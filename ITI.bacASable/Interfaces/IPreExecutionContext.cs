using System;
using System.Collections.Generic;
namespace ITI.bacASable
{
    public interface IPreExecutionContext
    {
        CILTypeManager TypeManager { get; }

        bool IsInClass { get; }

        bool IsInFunction { get; }

        int CurrentLineInstruction { get; }

        Dictionary<string, CILClass> Classes { get; }

        bool AddNewClass( string className );

        CILClass EndNewClass();

        CILProgram GetFinalProgram();

        bool AddLocalVariable(ICILType localVariable);

        bool AddLabel( LabelNode label );

        bool AddNewFunctionToCurrentClass( string name, ICILType returnType, List<ICILType> parameters );

        bool AddInstructionNodeToCurrentFunction( InstructionNode instruction );

        IFunction EndCurrentFunction();
    }
}
