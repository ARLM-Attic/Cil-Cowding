using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public interface IPreExecutionContext
    {
        Dictionary<string, int> Labels
        {
            get;
        }
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
        List<IFunction> PreExecut( List<FunctionNode> code );

        void AddLabel( KeyValuePair<string, int> label );
    }
}
