using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public interface IFonction
    {
        String GetSignature();
        String GetLabel();
        String GetTypeOfReturn();

        void AddLocalVariable(IVariable var);
        IVariable GetLocalVariable(String label);
        IVariable SetLocalVariable(IVariable var);


    }
}
