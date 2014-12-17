using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// 
    /// </summary>
    public class NopNode : InstructionNode
    {
        public override void Execute(IExecutionContext ctx)
        {
            throw new NotImplementedException();
        }
    }
}
