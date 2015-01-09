using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Push 1 (of type int32) if value2 > value1, else push 0
    /// </summary>
    public class CltNode : BinaryComparatorNode
    {
        public CltNode(int line)
            : base( line )
        {
        }
        public override IValue Comparator( IValue value1, IValue value2 )
        {
            IValue result;
            if ( (int)value1.Data < (int)value2.Data )
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
