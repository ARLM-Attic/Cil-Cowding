using System;
using System.Collections.Generic;

namespace ITI.bacASable
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

        List<InstructionNode> Body
        {
            get;
        }

        string GetSignature();
        void AddLocalVariable(IValue var);
        IValue GetLocalVariable(int index);
        IValue SetLocalVariable(IValue var);
        int GetIndexLabel(string label);
        void AddLabel( string label, int index );
        //List<IInstructionNode> GetInstructions();
    }
}
