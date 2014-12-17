using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public interface IPreExecutionContext
    {
        CILTypeManager TypeManager
        { get; }

        List<ICILType> LocalsVar
        {
            set;
            get;
        }



    }
}
