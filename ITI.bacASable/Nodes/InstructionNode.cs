using System;

namespace ITI.bacASable
{
    public abstract class InstructionNode : Node
    {
        protected InstructionNode( int line )
            : base( line )
        {
        }

        public abstract void Execute( IExecutionContext ctx );

        public override void PreExecute(IPreExecutionContext pec)
        {
            pec.AddInstructionNodeToCurrentFunction(this);

        }
    }



}
