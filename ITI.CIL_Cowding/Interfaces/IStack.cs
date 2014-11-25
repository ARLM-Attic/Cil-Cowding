using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public interface IStack
    {
        /// <summary>
        /// Récupère les variables qu'il y a sur la top-frame
        /// </summary>
        /// <returns>Stack des variables qu'il y a sur la TopFrame</returns>
        Stack<Variable> TopFrame ();


        IFrame GetLastFrame();

        void Push(IVariable var);
        IVariable Pop();
        void CallFonction(IFonction fct);
        void CloseFonction();


    }
}
