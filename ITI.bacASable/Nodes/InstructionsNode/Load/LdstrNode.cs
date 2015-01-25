using System;

namespace ITI.bacASable
{
    /// <summary>
    /// Push a string object for the literal string
    /// </summary>
    public class LdstrNode : InstructionNode
    {
        private string _str;
      public LdstrNode( string str, int line )
            : base( line )
        {
            this._str = str;
        }
        public override void Execute( IExecutionContext ctx )
        {
            ctx.Stack.Push( new Value( new CILNetType( typeof( string ) ), this._str ) );
        }
    }
}
