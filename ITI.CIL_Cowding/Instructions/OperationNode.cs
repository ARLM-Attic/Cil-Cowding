using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding.Instructions
{
    public class OperationNode : InstructionNode
    {
        public override void Execute( IExecutionContext ctx )
        {
            ctx.GetStack();
        }
    }
}
