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
        List<string> _parameters;
        List<InstructionNode> _code;

        public void PreExecute(Pre_ExecutionContext pec)
        {
            // Pour le moment rien, mais on remplira après :-)


        }

        public FunctionNode(string name, string typeReturn, List<InstructionNode> code, List<string> parameters)
        {
            _nomfct = name;
            _typeOfReturn = typeReturn;
            _code = code;
            _parameters = new List<string>();

            foreach(var variable in parameters) {
                _parameters.Add(variable);
            }


        }

    }
}
