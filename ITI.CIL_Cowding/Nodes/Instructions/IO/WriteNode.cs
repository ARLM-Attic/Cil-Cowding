using System;
namespace ITI.CIL_Cowding
{
    /// <summary>
    /// 
    /// </summary>
    public class WriteNode : InstructionNode
    {
        int _line;
        public override int Line
        {
            get { return _line; }
        }
        public WriteNode(int line)
        {
            _line = line;
        }
        public override void Execute( IExecutionContext ctx )
        {
            Console.WriteLine( ctx.Stack.Pop().Data );
        }
    }
}

