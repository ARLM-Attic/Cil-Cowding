using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Branch to target if value is non-zero (true).
    /// </summary>
    public class BrtrueNode : InstructionNode
    {
        string _label;

        public BrtrueNode(string label)
        {
            _label = label;
        }
        public override void Execute(IExecutionContext ctx)
        {
            IValue temp = ctx.Stack.Pop();
            if ( temp.Type.IsBool() && (int)temp.Data == 1 )
            {
                int index = ctx.Stack.LastFrame.Fct.GetIndexLabel( _label );
                ctx.Stack.LastFrame.SetCurrentInstruction( index );
            }
            else
            {
                //error
            }
        }
    }
}
