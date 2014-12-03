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
        
		public static Stack<IVariable> TopFrame
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

		public static void SetLocalVar(IVariable var) {
			
			var frame = Stack.LastFrame();
			frame.SetVar(var);
			
		}
		
		public static IVariable Pop() {
			if(TopFrame.Count == 0) {
                Console.WriteLine("ERREUR DANS LA STACK");
                return new Variable(null, "");
            }
			return TopFrame.Pop();
		
		}
		
		public static void Push(IVariable var) {
		
			TopFrame.Push(var);
		
		}
 
		
    }

	
}


