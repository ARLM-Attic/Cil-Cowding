using System;
using System.Collections.Generic;

namespace ITI.bacASable
{
    public class FunctionNode : Node
    {
        string _functionName;
        string _returnType;
        List<string> _parametersType;
        List<Node> _code;

        public string Name
        {
            get { return _functionName; }
        }
        public FunctionNode(string name, string returnType, List<Node> code, List<string> parametersType, int line)
            :base(line)
        {
            _functionName = name;
            _returnType = returnType;
            _code = code;
            _parametersType = new List<string>( parametersType );
        }
        public override void PreExecute(IPreExecutionContext pec)
        {
            List<ICILType> parametersType = new List<ICILType>();
            foreach (string parameter in _parametersType)
            {
                parametersType.Add( pec.TypeManager.Find( parameter ) );
            }

            if( pec.AddNewFunctionToCurrentClass( _functionName, pec.TypeManager.Find( _returnType ), parametersType ) )
            {
                foreach(Node node in _code)
                {
                    node.PreExecute( pec );
                }
                pec.EndCurrentFunction();
            }
            else
            {
                throw new NotImplementedException( "TODO: Add error to IPreExecutionContext" );
            }
        }

    }
}
















// La faute à Microsoft si les gens comprennent rien à l'informatique.





//La faute aux cassos si Apple se fait des couilles en poil de titanium.

// La faute à Aymeric si les commentaires sont complètement pourris ! ... Mais en même temps il a pas tord ...