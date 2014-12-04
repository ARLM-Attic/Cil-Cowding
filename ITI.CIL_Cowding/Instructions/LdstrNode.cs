using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public class LdstrNode : InstructionNode
    {
        string _str;

        public LdstrNode(string str)
        {
            _str = str;
        }

        public override void Execute(IExecutionContext ctx)
        {
            throw new NotImplementedException();
        }
    }
}
