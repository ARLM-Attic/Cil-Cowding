using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public interface IStack
    {

        Stack<IVariable> GetTopFrame ();

        IFrame GetLastFrame();

        void Push(IVariable var);

        IVariable Pop();

        void CallFonction(IFonction fct);
        
        void CloseFonction();


    }
}
