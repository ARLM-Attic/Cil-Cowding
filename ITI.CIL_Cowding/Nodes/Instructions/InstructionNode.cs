using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public abstract class InstructionNode : Node
    {
        public abstract void Execute( IExecutionContext ctx );
    }

        

}
