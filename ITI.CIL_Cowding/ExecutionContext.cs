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
        List<Function> _code;

        public IStack Stack
        {
            get { return _stack; }
        }

        public IHeap Heap
        {
            get { throw new NotImplementedException(); }
        }

        public ExecutionContext(List<Function>code)
        {

            _stack = new Stack();

            // Initialisation du code
            _code = code;
            // Pour le moment on ne lance que la première fct, mais après on lancera la fct Main
            _stack.CallFunction(_code[0]);

        }

        public void NextInstruction() {
            
            InstructionNode IN = _stack.LastFrame.CurrentInstruction;

            if (IN == null) { throw new NotImplementedException("Il faut gérer la fin du programme"); }

            else { IN.Execute(this); }
            // On passe à l'instruction suivante
            if(_stack.LastFrame == null) {
                throw new Exception("Le soft ne gère pas encore la fin d'un programme");
            } else {
                _stack.LastFrame.NextInstruction();
            }
            
        }

    }
}
