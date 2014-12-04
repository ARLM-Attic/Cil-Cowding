using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public class Stack : IStack 
    {
		// Fields		
        static Container _frame;
        static Stack<Variable> _topFrame;

        // Properties
        public static Container Frame
        {
            get { return _frame; } 
        }
        
		public static Stack<Variable> TopFrame
        {
            get { return _topFrame; }
        }
		
		private static Container LastFrame() 
        {
            // Code pour la V1, ça sera mis à jour par la suite.
            return _frame;
        }
       
		// Constructor
        public Stack() 
		{
            _frame = new Container();
            _topFrame = new Stack<Variable>();
		}

		// Methods
        public static IVariable GetLocalVar(String label) {
			Container frame = Stack.LastFrame();

			if(frame.IsExistVar(label)) {
			
				return frame.GetVar(label);
			} else {
				throw new Exception("Erreur GetLocalVar in the container");
			}
			
		}

		public static void SetLocalVar(Variable var) {
			
			var frame = Stack.LastFrame();
			frame.SetVar(var);
			
		}

		
       /**
        * Super Code Redou OTD !
        * 
        * **/

        public Stack<IVariable> GetTopFrame()
        {
            throw new NotImplementedException();
        }

        public IFrame GetLastFrame()
        {
            throw new NotImplementedException();
        }

        public void Push(IValue var)
        {
            throw new NotImplementedException();
        }

        public IValue Pop()
        {
            throw new NotImplementedException();
        }

        public void CallFonction(IFonction fct)
        {
            throw new NotImplementedException();
        }

        public void CloseFonction()
        {
            throw new NotImplementedException();
        }

    }

	
}


