using System;

namespace ITI.CIL_Cowding
{
    public class CallNode : InstructionNode
    {
        string _name;
        Function toCall;
        int _line;
        public override int Line
        {
            get { return _line; }
        }

        /// <summary>
        /// Call method, described by name
        /// </summary>
        /// <param name="name">Function name</param>
        public CallNode(string name, int line)
        {
            _name = name;
            _line = line;
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
