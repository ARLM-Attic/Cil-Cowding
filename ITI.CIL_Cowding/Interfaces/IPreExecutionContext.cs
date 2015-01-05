using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public interface IPreExecutionContext
    {
        
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

        Function CurrentFunction
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
