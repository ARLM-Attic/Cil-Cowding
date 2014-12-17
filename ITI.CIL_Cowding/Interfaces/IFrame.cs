using System;

namespace ITI.CIL_Cowding
{
    public interface IFrame
    {
        IFunction GetFunction();
        IValue GetVariable(int index);
        void SetVariable(IValue var);
        bool IsExistingVar(int index);
        void CloseFonction();

    }
}
