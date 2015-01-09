using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Push 1 (of type int32) if value1 equals value2, else push 0.
    /// </summary>
    public class CeqNode : BinaryComparatorNode
    {
        int _line;
        public override int Line
        {
            get { return _line; }
        }
        public CeqNode(int line)
        {
            _line = line;
        }
        public override IValue Comparator( IValue value1, IValue value2 )
        {
            IValue result;
            if ( value1.Data.ToString() == value2.Data.ToString() )
            {
                result = new Value( value1.Type, 1 );
            }
            else
            {
                result = new Value( value1.Type, 0 );
            }
            return result;
        }
    }
}
