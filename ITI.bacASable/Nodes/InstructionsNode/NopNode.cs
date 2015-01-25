using System;

namespace ITI.bacASable
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
