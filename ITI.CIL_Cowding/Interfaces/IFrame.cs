using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public interface IFrame
    {
        IFonction GetFonction();
        IVariable GetVariable(String label);
        void SetVariable(IVariable var);
        bool IsExistingVar(String label);
        void CloseFonction();

    }
}
