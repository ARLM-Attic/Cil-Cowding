using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// 
    /// </summary>
    public class WriteNode : InstructionNode
    {
        public override void Execute( IExecutionContext ctx )
        {
            Console.WriteLine( ctx.Stack.Pop().Data );
        }
    }
}

