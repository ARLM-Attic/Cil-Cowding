using System;

namespace ITI.CIL_Cowding
{
    public abstract class InstructionNode : Node
    {
        public InstructionNode( int line )
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
