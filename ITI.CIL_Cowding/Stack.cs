using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public class CIL_Stack 
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
        public CIL_Stack() 
		{
            _frame = new Container();
            _topFrame = new Stack<Variable>();
		}

		// Methods
        public static Variable GetLocalVar(String label) {
			Container frame = CIL_Stack.LastFrame();

			if(frame.IsExistVar(label)) {
			
				return frame.GetVar(label);
			} else {
				throw new Exception("Erreur GetLocalVar in the container");
			}
			
		}

		public static void SetLocalVar(Variable var) {
			
			var frame = CIL_Stack.LastFrame();
			frame.SetVar(var);
			
		}
		
		public static Variable PopVar() {
			if(TopFrame.Count == 0) {
                Console.WriteLine("ERREUR DANS LA STACK");
                return new Variable(VarType.Var_None, "", "");
            }
			return TopFrame.Pop();
		
		}
		
		public static void PushVar(Variable var) {
		
			TopFrame.Push(var);
		
		}
 
		
    }

	
}


