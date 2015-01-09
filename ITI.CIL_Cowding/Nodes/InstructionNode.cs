using System;

namespace ITI.CIL_Cowding
{
    public abstract class InstructionNode : Node
    {
        protected InstructionNode( int line )
            : base( line )
        {
        }

        public abstract void Execute( IExecutionContext ctx );
    }

        

}
