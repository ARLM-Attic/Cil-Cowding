using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Do nothing, but do it like a boss
    /// </summary>
    public class NopNode : InstructionNode
    {
       public NopNode( int line )
            : base( line )
        {
        }
        public override void Execute(IExecutionContext ctx)
        {
        }
    }
}
