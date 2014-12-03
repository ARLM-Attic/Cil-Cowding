using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public interface IValue
    {
       ICILType Type
        {
            get ;
            set ;
        }

       Object Data
        {
            get ;
        }

    }
}



