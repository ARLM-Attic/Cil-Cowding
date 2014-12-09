using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public class LdcNode : InstructionNode
    {
        private int _val;
        public LdcNode( int val )
        {
            this._val = val;
        }
        public override void Execute( IExecutionContext ctx )
        {
            ctx.Stack.Push( new Value( new CILNetType( typeof( int ) ), this._val ) );
        }
    }
}
