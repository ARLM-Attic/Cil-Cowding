using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Push a string object for the literal string
    /// </summary>
    public class LdstrNode : InstructionNode
    {
        private string _str;
        public LdstrNode( string str )
        {
            this._str = str;
        }
        public override void Execute( IExecutionContext ctx )
        {
            ctx.Stack.Push( new Value( new CILNetType( typeof( string ) ), this._str ) );
        }
    }
}
