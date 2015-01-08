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
        Type _externFunction;
        string _nameOfMethod;
        
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
                _fctToCall = null;
                _externFunction = (Type)function;
                _nameOfMethod = _labels[_labels.Count - 1];
            }
            else if( fcs == FunctionScope.Internal )
            {
                _fctToCall = (Function)function;
                _externFunction = null;
            }
            else
            {
                pec.AddError( "Error : Function not found." );
            }
        }

        public override void Execute(IExecutionContext ctx)
        {
            if(_fctToCall != null) 
            {
                ctx.Stack.CallFunction(_fctToCall);

            } 
            else if (_externFunction != null)
            {
                List<IValue> parameters = new List<IValue>();
                List<Type> args = new List<Type>();

                // POP tout les args
                while (ctx.Stack.IsStackContainsSomething) 
                {

                    parameters.Add( ctx.Stack.Pop() );

                }

                foreach(var i in parameters) {
                    args.Add(i.Type.RealType);
                }

                Type[] real_args = args.ToArray();

                // Recup la bonne méthode
                MethodInfo _method = _externFunction.GetMethod(_nameOfMethod, real_args);

                // SUPER INVOKE OTD !
                _method.Invoke(null,(Object[])parameters.ToArray());




            } else {
                throw new Exception("fcttoCall and externFunction are both null ???");
            }
        }
    
    
    }
}