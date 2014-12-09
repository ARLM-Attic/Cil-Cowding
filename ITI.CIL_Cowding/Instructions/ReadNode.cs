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
    public class ReadNode : InstructionNode
    {
        public override void Execute( IExecutionContext ctx )
        {
            Console.Write( "Input ==> " );
            ctx.Stack.Push( new Value( new CILNetType( typeof( int ) ), Console.ReadLine() ) );
        }
    }
}
