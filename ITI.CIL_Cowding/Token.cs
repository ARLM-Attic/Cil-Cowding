using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public class Token
    {
        // Fields
        TokenType _type;
        String _data;

        public String Data
        {
            get{return _data;}
            //set{_data = value;}
        }
        public TokenType Type
        {
            get { return _type; }
            //set { _type = value; }
        }

        // Constructor
        public Token(TokenType tk_type, String data)
        {
            _type = tk_type;
            _data = data;

        }


        // Methodes


    }
}
