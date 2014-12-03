using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    class Variable : IVariable
    {
        Value _value;
        string _label;

        public Variable(Value value, string label)
        {
            _value = value;
            _label = label;
        }
    }
}
