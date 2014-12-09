using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    internal class VarNode : InstructionNode
    {
        private IValue val;
        private string label;
        public VarNode( string type )
        {
            
        }
        public override void Execute( IExecutionContext ctx )
        {
            ctx.Stack.SetLocalVar( this.val );
        }
    }
}
