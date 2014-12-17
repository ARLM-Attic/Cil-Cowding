using System;

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



