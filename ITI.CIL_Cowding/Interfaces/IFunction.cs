using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public interface IFunction
    {
        String GetSignature();
        List<ICILType> LocVar
        {
            get;
        }
        List<InstructionNode> Code
        {
            get;
        }

        void AddLocalVariable(IValue var);
        IValue GetLocalVariable(int index);
        IValue SetLocalVariable(IValue var);

        //List<IInstructionNode> GetInstructions();

    }
}
