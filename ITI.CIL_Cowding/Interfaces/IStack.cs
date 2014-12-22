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

        List<Container> Frame
        { 
            get; 
        }

        Stack<IValue> TopFrame { get; }
    }
}
