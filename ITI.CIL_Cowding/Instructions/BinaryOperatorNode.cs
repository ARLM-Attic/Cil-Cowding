using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public abstract class BinaryOperatorNode : InstructionNode
    {
        protected abstract IValue Operator (IValue value1, IValue value2);
        public override sealed void Execute( IExecutionContext ctx )
        {
            IValue temp1 = ctx.GetStack().Pop();
            IValue temp2 = ctx.GetStack().Pop();
            if ( ( temp1.Type == temp2.Type ) && temp1.Type.IsNumeric )
            {
                ctx.GetStack().Push( Operator( temp2, temp1 ) ) ;
            }
            else
            {
                //error
            }
            
        }
    }
}
