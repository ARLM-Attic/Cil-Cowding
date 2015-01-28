using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public class CILClass
    {
        Dictionary<string, IFunction> _functions;

        public CILClass( Dictionary<string, IFunction> functions )
        {
            _functions = functions;
        }

        public Dictionary<string, IFunction> Functions
        {
            get { return _functions; }
        }
    }
}
