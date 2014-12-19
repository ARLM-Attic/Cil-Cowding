using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Branch to target if value is zero (false).
    /// </summary>
    public class BrfalseNode : InstructionNode
    {
        string _label;

        public BrfalseNode(string label)
        {
            _label = label;
        }

        public override void Execute(IExecutionContext ctx)
        {
            IValue temp = ctx.Stack.Pop();
            if ( temp.Type.IsBool() && (int)temp.Data == 0 )
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
