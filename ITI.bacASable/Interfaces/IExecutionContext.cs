using System;

namespace ITI.bacASable
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
