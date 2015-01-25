using System;
using System.Collections.Generic;
using System.Reflection;

namespace ITI.bacASable
{

    public enum FunctionScope
    {
        None,
        Internal,
        External
    }

    public class CallNode : InstructionNode
    {
        //string _name;
       // Function toCall;
        List<string> _labels;
        Function _fctToCall;
        Type _externFunction;
        string _nameOfMethod;
        
        /// <summary>
        /// Call method, described by name
        /// </summary>
        /// <param name="name">Function name</param>
        public CallNode(List<string> label, int line)
            : base( line )
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
                _nameOfMethod = _labels[_labels.Count - 1];

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

                List<IValue> parameters = new List<IValue>();   // Param CIL_Cowding
                List<Type> args_type = new List<Type>();        // Types Réel déduit 
                List<dynamic> variables = new List<dynamic>();    // Véritables variables
                List<Object> realvar = new List<Object>();

                // POP tout les paramètres qu'envoi l'utilisateur
                while (ctx.Stack.IsStackContainsSomething) 
                {
                    parameters.Add( ctx.Stack.Pop() );
                }

                // Récupération des vrais Types
                foreach(var i in parameters) {
                    args_type.Add(i.Type.RealType);
                }

                // Recup la bonne méthode
                MethodInfo _method = _externFunction.GetMethod(_nameOfMethod, args_type.ToArray());

                // Get RealVariables :D
                foreach(var i in parameters) 
                {
                    realvar.Add(i.Data);
                }

                // SUPER INVOKE OTD !
                _method.Invoke(null,realvar.ToArray());




            } else {
                throw new Exception("fcttoCall and externFunction are both null ???");
            }
        }
    
    
    }
}