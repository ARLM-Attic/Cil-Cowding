using System;

namespace ITI.bacASable
{
    public abstract class InstructionNode : Node
    {
        protected InstructionNode( int line )
            : base( line )
        {
        }

        public abstract void Execute(  );

        public override void PreExecute(PreExecutionContext pec)
        {
            pec.AddInstructionNodeToCurrentFunction(this);

        }
    }



}
