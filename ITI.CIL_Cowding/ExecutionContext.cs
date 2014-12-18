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
        List<IFunction> _code;

        public IStack Stack
        {
            get { return _stack; }
        }

        public IHeap Heap
        {
            get { throw new NotImplementedException(); }
        }

        public ExecutionContext(List<IFunction>code)
        {

            _stack = new Stack();

            // Initialisation du code
            _code = code;
            // Pour le moment on ne lance que la première fct, mais après on lancera la fct Main
            _stack.CallFunction(_code[0]);

        }

        public void NextInstruction() {

            _stack.LastFrame.CurrentInstruction.Execute(this);
            
        }

    }
}
