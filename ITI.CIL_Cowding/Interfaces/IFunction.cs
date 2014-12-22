using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public interface IFunction
    {
        string Name
        {
            get;
        }
        ICILType ReturnType
        {
            get;
        }
        List<ICILType> LocVar
        {
            get;
        }
        List<ICILType> ArgVar
        {
            get;
        }

        List<InstructionNode> Code
        {
            get;
        }

        string GetSignature();
        void AddLocalVariable(IValue var);
        IValue GetLocalVariable(int index);
        IValue SetLocalVariable(IValue var);
        int GetIndexLabel(string label);

        //List<IInstructionNode> GetInstructions();
    }
}
