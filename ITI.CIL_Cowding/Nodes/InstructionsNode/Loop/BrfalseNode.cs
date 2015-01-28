using System;

namespace ITI.CIL_Cowding
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
            if ( (temp.Type.IsInt32()||temp.Type.IsDouble()) )
            {
                if (temp.Type.IsDouble() && ((double)temp.Data == 0 || (double)temp.Data == 1))
                {
                    if ((double)temp.Data == 1)// Pay attention, int atm, bool for next
                    {
                        int index = ctx.Stack.LastFrame.Fct.GetIndexLabel(_label);
                        ctx.Stack.LastFrame.SetCurrentInstruction(index);
                    }
                    else if ((double)temp.Data == 0)
                    {
                        // don't branch
                    }
                }
                else if (temp.Type.IsInt32() && ((int)temp.Data == 0 || (int)temp.Data == 1))
                {
                    if ((int)temp.Data == 1)// Pay attention, int atm, bool for next
                    {
                        int index = ctx.Stack.LastFrame.Fct.GetIndexLabel(_label);
                        ctx.Stack.LastFrame.SetCurrentInstruction(index);
                    }
                    else if ((int)temp.Data == 0)
                    {
                        // don't branch
                    }
                }
                
            }
            else
            {
                ctx.AddError( "Brfalse expect a boolean, 0 or 1." );
            }
        }
    }
}
