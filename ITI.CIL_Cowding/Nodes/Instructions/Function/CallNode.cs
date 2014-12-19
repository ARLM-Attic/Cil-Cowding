using System;

namespace ITI.CIL_Cowding
{
    public class CallNode : InstructionNode
    {
        // Fields

        string _label;
        Function fct_a_appeller;


        public CallNode(string label)
        {
            _label = label;
        }

        public override void PreExecute(IPreExecutionContext pec)
        {
            
            fct_a_appeller = pec.SearchFunction(_label);

        }

        public override void Execute(IExecutionContext ctx)
        {
            ctx.Stack.CallFunction(fct_a_appeller);
        }
    }
}
