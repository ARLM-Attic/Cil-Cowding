using System;

namespace ITI.CIL_Cowding
{
    public interface IExecutionContext
    {
        IStack Stack
        {
            get;
        }
        IHeap Heap
        {
            get;
        }

        bool NextInstruction();
        void AddError( string msg );
    }
}
