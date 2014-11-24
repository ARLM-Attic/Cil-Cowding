using System;

namespace ITI.CIL_Cowding
{
    public struct Signature
    {

        String _name;
        VarType _typeOfReturn;
        List<Variable> _args;

        public Signature (String name, VarType typeOfReturn,List<Variable> args) 
        {
            _name = name;
            _typeOfReturn = typeOfReturn;
            _args = args;
        }

        public String getSignature () 
        {
            String message = "" + _varReturn + " " + _label;

            foreach(Variable variable in _args) 
            {
                message += " " + variable.Type + " " + variable.Data;
            }

            return message;
        }

    }


}


