using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// 
    /// </summary>
    internal class VarNode : InstructionNode
    {
        private IValue val;
        private string label;
        public VarNode( CILNetType type, string label )
        {
            this.val = new Value( type, null );
        }
        public override void Execute( IExecutionContext ctx )
        {
            ctx.Stack.SetLocalVar( this.val );
        }
    }
}
