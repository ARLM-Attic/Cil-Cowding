using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public class FunctionNode : Node
    {
        string _nomfct;
        string _typeOfReturn;
        List<string> _parametres;
        List<InstructionNode> _code;

        public void PreExecute(Pre_ExecutionContext pec)
        {
            // Pour le moment rien, mais on remplira après :-)


        }

        public FunctionNode(string name, string typereturn, List<InstructionNode> code, List<string> parametres)
        {
            _nomfct = name;
            _typeOfReturn = typereturn;
            _code = code;
            _parametres = new List<string>();

            foreach(var variable in parametres) {
                _parametres.Add(variable);
            }


        }

    }
}
