using System;

namespace ITI.CIL_Cowding
{
    public class CallNode : InstructionNode
    {
        string _name;
        Function toCall;

        /// <summary>
        /// Call method, described by name
        /// </summary>
        /// <param name="name">Function name</param>
        public CallNode(string name, int line)
            : base( line )
        {
            _name = name;
        }

        public override void PreExecute(IPreExecutionContext pec)
        {

            toCall = pec.SearchFunction( _name );

        }

        public override void Execute(IExecutionContext ctx)
        {
            ctx.Stack.CallFunction(toCall);
        }
    }
}
