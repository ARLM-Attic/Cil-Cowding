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

        void NextInstruction();
    }
}
