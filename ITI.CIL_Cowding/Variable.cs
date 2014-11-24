using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{

    public enum VarType {
        Var_None,
        Var_Int,
        Var_String,
		Var_Bool
    };

    public class Variable
    {
        // Fields
        VarType _type;
        String _data;
		String _label;

        public VarType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        
		public String Data
        {
            get { return _data; }
        }
        
		public String Label
        {
            get { return _label; }
            set { _label = value; }
        }

        // Constructor
        public Variable(VarType vartype, String data, String label="")
        {
            // Verification


            // Attribution
            _type = vartype;
            _data = data;
			_label = label;

        }

		// Methodes
		
		
		
        // Methodes
       /* public String Label() {
			return _label;
		}
        */


    }

	
	
}
