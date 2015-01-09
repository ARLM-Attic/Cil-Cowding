using System;
using System.Collections.Generic;


namespace ITI.CIL_Cowding
{
    public interface IStack
    {
        void Push(IValue var);

        IValue Pop();

        void CallFunction(IFunction fct);
        
        void CloseFunction();

        IValue GetLocalVar(int index);

        void SetLocalVar( IValue var, int index );

        Container LastFrame
        {
            get;
        }

        IValue GetArgVar(int index);
        void SetArgVar(int index, IValue var);

        Stack<IValue> TopFrame { get; }
        List<Container> Frame { get; }

        bool IsStackContainsSomething { get; }


    }
}
