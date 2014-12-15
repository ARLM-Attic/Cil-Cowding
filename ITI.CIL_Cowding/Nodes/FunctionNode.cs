using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public class FunctionNode : Node
    {
        string _namefct;
        string _returnType;
        List<string> _parameters;
        List<InstructionNode> _code;


        public FunctionNode(string name, string returnType, List<InstructionNode> code, List<string> parameters)
        {
            _namefct = name;
            _returnType = returnType;
            _code = code;
            _parameters = new List<string>();

            foreach(string variable in parameters) 
            {
                _parameters.Add(variable);
            }
        }
        public Function PreExecute(PreExecutionContext pec)
        {
            ICILType returnType;
            List<IValue> parameters = new List<IValue>();
            List<IValue> locvar = new List<IValue>();


            // Gestion du type de retour
            returnType = pec.TypeManager.Find(_returnType);

            // Gestion des types de paramètres
            foreach (string str in _parameters)
            {
                parameters.Add( new Value(pec.TypeManager.Find( str ), null) );
            }

            // Gestion des types des locvar
            if( _code[0] is LocalsInitNode ) 
            {
                _code[0].PreExecute(pec);
            }

            return new Function( _namefct, returnType, parameters, pec.LocalsVar,  _code );
        }

    }
}
















// La faute à Microsoft si les gens comprennent rien à l'informatique.





//La faute aux cassos si Apple se fait des couilles en poil de titanium.