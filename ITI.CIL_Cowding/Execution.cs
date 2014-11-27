using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{


    public class Execution
    {

        List<Instruction> _code;
		int _index;
		CIL_Stack _stack;

        // Properties


        // Constructor
        public Execution(string file)
        {
			_stack = new CIL_Stack();
            // Verification
            
            // Tokenizer
            //_code = StringTokenizer.Tokenize(file); 

            // Pour la prochaine version, on va analyser la liste d'instruction pour ensuite découper les classes et mettre les methodes et les champs dans les classes
            Console.Clear();
			_index=-1;
		
		}
        
		
		public void ExecLine() {
            int _index_return=0;

            if(++_index < _code.Count) {
                _index_return = _code[_index].Execute();
            }
            else
            {
                Console.WriteLine("Fin du programme");
                _index_return = -1;
            }
			
			
			if(_index_return != -1) {
				_index=_index_return-1;
			} else {
				// NOTHING
			}
			
			
        }




    }
}
