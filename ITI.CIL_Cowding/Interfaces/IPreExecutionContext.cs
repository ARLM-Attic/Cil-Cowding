using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public interface IPreExecutionContext
    {
        
        List<SyntaxError> Errors
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

        Function SearchFunction(string nomFct);
    }
}
