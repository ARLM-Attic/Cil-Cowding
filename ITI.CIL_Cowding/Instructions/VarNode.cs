using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    class VarNode : InstructionNode
    {
        Value val;
        string label;

        public VarNode(string type, string label)
        {

        }

        public override void Execute(IExecutionContext ctx)
        {
            throw new NotImplementedException();
        }


    }
}
