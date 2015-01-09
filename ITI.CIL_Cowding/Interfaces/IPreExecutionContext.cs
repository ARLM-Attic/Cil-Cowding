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

        IFunction CurrentFunction
        {
            get;
        }

        int CurrentLineInstruction
        {
            get;
        }


        List<IFunction> PreExecut( List<FunctionNode> code );

        Function SearchFunction(string nomFct);
    }
}
