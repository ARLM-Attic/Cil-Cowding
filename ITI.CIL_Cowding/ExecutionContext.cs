using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public class ExecutionContext : IExecutionContext
    {
        Stack _stack;
        CILProgram _cilProgram;
        IEngine _engine;
        IError _error;


        public IStack Stack
        {
            get { return _stack; }
        }

        public IHeap Heap
        {
            get { throw new NotImplementedException(); }
        }

        public ExecutionContext(CILProgram code, IEngine engine)
        {
            _stack = new Stack(engine);
            _engine = engine;

            // Initialisation du code
            _cilProgram = code;
            // Pour le moment on ne lance que la première fct, mais après on lancera la fct Main
            _stack.CallFunction( "main");

        }

            
        public bool NextInstruction () {

            if (_stack.LastFrame == null)
            {
                return false;
            }
            _stack.LastFrame.CurrentInstruction.Execute( this );

            // On passe à l'instruction suivante si on n'a pas d'erreur
            if(_error != null || _stack.LastFrame == null) 
            {
                return false ;
            } 
            else 
            {
                _stack.LastFrame.NextInstruction();
            }
            return true;
        }

        public void AddError( string msg )
        {
            _error  = new RunTimeError(_engine, msg);
            _engine.ClashError(_error);
            
        }
    }
}
