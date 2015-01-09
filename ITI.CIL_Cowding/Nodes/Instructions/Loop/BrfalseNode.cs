using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Branch to target if value is zero (false).
    /// </summary>
    public class BrfalseNode : InstructionNode
    {
        string _label;
        int _line;
        public override int Line
        {
            get { return _line; }
        }

        public BrfalseNode(string label, int line)
        {
            _label = label;
            _line = line;
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
