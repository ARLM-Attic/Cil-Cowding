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
        private string _type;
        public VarNode( string type )
        {
            _type = type;
        }
        public override void Execute( IExecutionContext ctx )
        {
            
        }
        public void Pre_Execute(PreExecutionContext pre_ctx) 
        {
            //pre_ctx.Stack.CreateVar( _type );
        }
    }
}
