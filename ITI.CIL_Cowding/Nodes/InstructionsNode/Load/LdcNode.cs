using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Push num of type int32 onto the stack as int32.
    /// </summary>
    public class LdcNode : InstructionNode
    {
        private int _val;
       public LdcNode( int val, int line )
            : base( line )
        {
            this._val = val;
        }
        public override void Execute( IExecutionContext ctx )
        {
            ctx.Stack.Push( new Value( new CILNetType( typeof( int ) ), this._val ) );
        }
    }
}
