using System;

namespace ITI.bacASable
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
           get;
           set;
       }

    }
}



