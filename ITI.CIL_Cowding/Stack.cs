using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public class Stack : IStack 
    {
        static Container _frame;
        static Stack<IValue> _topFrame;

        public Stack<IValue> TopFrame
        {
            get { return _topFrame; }
        }

        public Container LastFrame
        {
            get { return _frame; }
        }
    
        public static Container Frame
        {
            get { return _frame; } 
        }

        public void CallFunction( IFunction fct )
        {
            throw new NotImplementedException();
        }

        public Stack() 
		{
            _frame = new Container();
            _topFrame = new Stack<IValue>();
		}

        public IValue GetLocalVar( int index )
        {
            Container frame = LastFrame;
            return frame.GetVar( index );
        }
        public void SetLocalVar( IValue var )
        {
            Container frame = LastFrame;
            frame.SetVar( var );
        }
        public void CloseFunction()
        {
            throw new NotImplementedException();
        }

        	
       /**
        * Super Code Redou OTD !
        * 
        * **/
        public void Push(IValue var)
        {
            throw new NotImplementedException();
        }

        public IValue Pop()
        {
            throw new NotImplementedException();
        }

        public void CallFonction(IFunction fct)
        {
            throw new NotImplementedException();
        }

        public void CloseFonction()
        {
            throw new NotImplementedException();
        }

    }

	
}


