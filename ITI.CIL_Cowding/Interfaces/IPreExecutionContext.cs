using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public interface IPreExecutionContext
    {
        CILTypeManager TypeManager
        { get; }

        List<IValue> LocalsVar
        {
            set;
            get;
        }



    }
}
