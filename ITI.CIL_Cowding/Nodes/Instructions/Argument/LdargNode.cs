using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Load local variable of specified index onto stack.
    /// </summary>
    public class LdargNode : InstructionNode
    {

        private int _index;
        public LdargNode(int index)
        {
            _index = index;
        }
        public override void Execute(IExecutionContext ctx)
        {
            ctx.Stack.Push(ctx.Stack.GetArgVar(_index));
        }
    }
}
