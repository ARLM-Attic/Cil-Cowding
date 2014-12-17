using System;

namespace ITI.CIL_Cowding
{
    public interface IFunction
    {
        String GetSignature();

        void AddLocalVariable(IValue var);
        IValue GetLocalVariable(int index);
        IValue SetLocalVariable(IValue var);

        //List<IInstructionNode> GetInstructions();

    }
}
