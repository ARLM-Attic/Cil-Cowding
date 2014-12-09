using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public class LdstrNode : InstructionNode
    {
        private string _str;
        public LdstrNode( string str )
        {
            this._str = str;
        }
        public override void Execute( IExecutionContext ctx )
        {
            ctx.Stack.Push( new Value( new CILNetType( typeof( string ) ), this._str ) );
        }
    }
}
