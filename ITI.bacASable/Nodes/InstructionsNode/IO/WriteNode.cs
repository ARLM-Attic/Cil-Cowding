using System;
namespace ITI.bacASable
{
    /// <summary>
    /// 
    /// </summary>
    public class WriteNode : InstructionNode
    {
        public WriteNode(int line)
            : base( line )
        {
        }
        public override void Execute( IExecutionContext ctx )
        {
            Console.WriteLine( ctx.Stack.Pop().Data );
        }
    }
}

