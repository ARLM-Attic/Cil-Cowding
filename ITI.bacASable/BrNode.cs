using System;

namespace ITI.bacASable
{
    /// <summary>
    /// Branch to target.
    /// </summary>
    public class BrNode : InstructionNode
    {
        string _label;
        public BrNode( string label, int line )
            : base( line )
        {
            _label = label;
        }

        public override void Execute(  )
        {
            
        }
    }
}
