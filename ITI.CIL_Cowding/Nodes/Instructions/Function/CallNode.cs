using System;
using System.Collections.Generic;
using System.Reflection;

namespace ITI.CIL_Cowding
{

    public enum FunctionScope
    {
        Internal,
        External, 
        None
    }

    public class CallNode : InstructionNode
    {
        // Fields

        List<string> _labels;
        Function _fctToCall;
        Object _externFunction;
        
        public CallNode(List<string> label)
        {
            _labels = label;
            _externFunction = null;
            _fctToCall = null;
        }

        public override void PreExecute(IPreExecutionContext pec)
        {
            Object function;
            FunctionScope fcs = pec.SearchFunction(_labels, out function);
            if( fcs == FunctionScope.External )
            {

            }
            else if( fcs == FunctionScope.Internal )
            {

            }
            else
            {
                pec.AddError( "Error : Function not found." );
            }
        }

        public override void Execute(IExecutionContext ctx)
        {
            ctx.Stack.CallFunction(_fctToCall);
        }
    }
}