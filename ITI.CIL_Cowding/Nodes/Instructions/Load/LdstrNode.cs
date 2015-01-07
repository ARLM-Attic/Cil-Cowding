using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Push a string object for the literal string
    /// </summary>
    public class LdstrNode : InstructionNode
    {
        private string _str;
        int _line;
        public override int Line
        {
            get { return _line; }
        }
        public LdstrNode( string str, int line )
        {
            this._str = str;
            _line = line;
        }
        public override void Execute( IExecutionContext ctx )
        {
            ctx.Stack.Push( new Value( new CILNetType( typeof( string ) ), this._str ) );
        }
    }
}
