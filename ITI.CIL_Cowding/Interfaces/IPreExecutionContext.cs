using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public interface IPreExecutionContext
    {

        bool BeginNewClass( string name );


        bool AddNewFunctionToCurrentClass( string name );

        bool AddInstructionNodeToCurrentFunction( InstructionNode instr );

        List<InstructionNode> EndCurrentFunction();

        void EndCurrentClass();


        List<IError> Errors
        {
            get;
        }
        CILTypeManager TypeManager
        { get; }

        List<ICILType> LocalsVar
        {
            set;
            get;
        }

        IFunction CurrentFunction
        {
            get;
        }

        int CurrentLineInstruction
        {
            get;
        }


        List<IFunction> PreExecut( List<FunctionNode> code );

        FunctionScope SearchFunction(List<string> labels, out Object function);

        void AddError(string p);
    }
}
