using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Push 1 (of type int32) if value2 > value1, else push 0
    /// </summary>
    public class CltNode : BinaryComparatorNode
    {
        int _line;
        public override int Line
        {
            get { return _line; }
        }
        public CltNode(int line)
        {
            _line = line;
        }
        public override IValue Comparator( IValue value1, IValue value2 )
        {
            IValue result;
            if (value1.Type.FullName == "System.Int32") 
            { 
                if ( (int)value1.Data < (int)value2.Data )
                {
                    result = new Value( value1.Type, 1 );
                }
                else
                {
                    result = new Value( value1.Type, 0 );
                }
            }
            else if (value1.Type.FullName == "System.Double")
            {
                if ((double)value1.Data < (double)value2.Data)
                {
                    result = new Value(value1.Type, 1.0);
                }
                else
                {
                    result = new Value(value1.Type, 0.0);
                }
            }
            else 
            {
                result = new Value(value1.Type, 0);
            }
            
            return result;
        }
    }
}
