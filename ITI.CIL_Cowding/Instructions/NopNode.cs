using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public class NopNode : InstructionNode
    {
        public override void Execute(IExecutionContext ctx)
        {
            throw new NotImplementedException();
        }
    }
}
