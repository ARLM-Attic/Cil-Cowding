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
        List<FunctionNode> _methods;
        //string _name;
       // Function toCall;
        List<string> _labels;
        string _fctToCall;
        Type _externFunction;
        string _nameOfMethod;
        
        /// <summary>
        /// Call method, described by name
        /// </summary>
        /// <param name="name">Function name</param>
        public CallNode(List<FunctionNode> methods, List<string> label, int line)
            : base( line )
        {
            _methods = methods;
            _labels = label;
            _externFunction = null;
            _fctToCall = null;
        }

      
        public override void PreExecute(IPreExecutionContext pec)
        {
            base.PreExecute( pec );
            Object function;

            FunctionScope fcs = SearchFunction(_labels, pec, out function);

            if( fcs == FunctionScope.External )
            {
                _fctToCall = null;
                _externFunction = (Type)function;
                _nameOfMethod = _labels[_labels.Count - 1];
            }
            else if( fcs == FunctionScope.Internal )
            {
                _fctToCall = (string)function;
                _externFunction = null;
                _nameOfMethod = _labels[_labels.Count - 1];

            }
            else
            {
                throw new NotImplementedException( "TODO : Adderror function not found" );
            }

        }

        public override void Execute(IExecutionContext ctx)
        {
            if(_fctToCall != null) 
            {
                ctx.Stack.CallFunction(_fctToCall );

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


        public FunctionScope SearchFunction( List<string> labels, IPreExecutionContext pec, out Object function )
        {
            // Verif' null toussa magueule

            // We looking for a function at home
            // On ne gère pas les classes internes (pour le moment). VIVE LA FRANCE \o/

            if ( labels.Count == 1 )
            {
                foreach ( FunctionNode fct in _methods)
                {
                    if ( fct.Name == labels[0] )
                    {
                        function = fct.Name;
                        return FunctionScope.Internal;
                    }
                }
            }

            // We looking for a function which is not at home
            string nameType = labels[0];

            for ( int i = 1 ; i < labels.Count - 1 ; i++ )
            {
                nameType += "." + labels[i];
            }

            Type type = Type.GetType( nameType );
            if ( type != null )
            {
                function = type;
                return FunctionScope.External;
            }
            else
            {
                // Add error
                function = null;
                return FunctionScope.None;
            }
        }
    
    }
}