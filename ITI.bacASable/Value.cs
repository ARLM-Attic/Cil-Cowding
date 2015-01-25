using System;

namespace ITI.bacASable
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
            set { _data = value; }
        }

        public Value( ICILType vartype, Object data )
        {
            _type = vartype;
            _data = data;
        }

        

        
    }
}
