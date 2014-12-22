using System;

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
            ctx.Stack.Push( new Value( new CILNetType( typeof( string ) ), Console.ReadLine() ) );
        }
    }
}
