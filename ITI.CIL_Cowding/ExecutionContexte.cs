using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public class ExecutionContext : IExecutionContext
    {
        Stack _stack;
        int _currentLine;


        public IStack Stack
        {
            get { return _stack; }
        }

        public IHeap Heap
        {
            get { throw new NotImplementedException(); }
        }

        public int CurrentLine
        {
            get {return _currentLine;}
        }
        public ExecutionContext()
        {
            _stack = new Stack();
            _currentLine = 1;
        }



    }
}
