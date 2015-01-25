using System;

namespace ITI.bacASable
{
    /// <summary>
    /// Load local variable of specified index onto stack.
    /// </summary>
    public class LdargNode : InstructionNode
    {
        private int _index;
        public LdargNode(int index, int line)
            : base( line )
        {
            _index = index;
        }
        public override void Execute(IExecutionContext ctx)
        {
            ctx.Stack.Push(ctx.Stack.GetArgVar(_index));
        }
    }
}
