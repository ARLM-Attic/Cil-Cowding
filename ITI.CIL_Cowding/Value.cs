using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public class Value : IValue
    {
        ICILType _type;
        Object _data;

        public ICILType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        
		public Object Data
        {
            get { return _data; }
        }

        public Value( ICILType vartype, Object data )
        {
            _type = vartype;
            _data = data;
        }
    }
}
