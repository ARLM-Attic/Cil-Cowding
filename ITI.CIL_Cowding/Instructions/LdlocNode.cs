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
    public class LdlocNode : InstructionNode
    {
        private string _label;
        public LdlocNode( string label )
        {
            this._label = label;
        }
        public override void Execute( IExecutionContext ctx )
        {
            ctx.Stack.Push( ctx.Stack.GetLocalVar( this._label ) );
        }
    }
}
