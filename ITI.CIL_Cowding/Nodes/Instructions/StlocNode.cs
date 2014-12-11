using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Pop a value from stack into local variable.
    /// </summary>
    public class StlocNode : InstructionNode
    {
        private string _label;
        public StlocNode( string label )
        {
            this._label = label;
        }
        public override void Execute( IExecutionContext ctx )
        {
            ctx.Stack.SetLocalVar( ctx.Stack.Pop() );
        }
    }
}
