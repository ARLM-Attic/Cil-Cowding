using System;

namespace ITI.bacASable
{
    /// <summary>
    /// Branch to target if value is zero (false).
    /// </summary>
    public class BrfalseNode : InstructionNode
    {
        string _label;
       public BrfalseNode(string label, int line)
            : base( line )
        {
            _label = label;
        }

        public override void Execute(IExecutionContext ctx)
        {
            IValue temp = ctx.Stack.Pop();
            if ( temp.Type.IsInt32() && ( (int)temp.Data == 0 || (int)temp.Data == 1 ) )
            {
                if ((int)temp.Data == 0)
                {
                    int index = ctx.Stack.LastFrame.Fct.GetIndexLabel( _label );
                    ctx.Stack.LastFrame.SetCurrentInstruction( index );
                }
                else if ((int)temp.Data == 1)
                {
                    //don't branch
                }
            }
            else
            {
                ctx.AddError( "Brfalse expect a boolean, 0 or 1." );
            }
        }
    }
}
