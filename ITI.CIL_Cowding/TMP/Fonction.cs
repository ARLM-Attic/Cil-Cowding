using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    class Fonction
    {
        // Fields
        List<Instruction> _code;
        Signature _sign;



        // Constructor
        public Fonction(Signature sign, List<Instruction> code)
        {
            _sign = sign;
            _code = code;
        }

        // Methodes
        public String GetSignature()
        {
            return _sign.getSignature;
        }


    }
}
