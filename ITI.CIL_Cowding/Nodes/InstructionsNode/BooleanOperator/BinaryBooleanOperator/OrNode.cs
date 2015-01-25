using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Bitwise OR of two integer values, returns an integer.
    /// </summary>
    public class OrNode : BinaryBooleanOperatorNode
    {
        public OrNode(int line)
            : base( line )
        {
        }
        protected override IValue Operator( IValue value1, IValue value2 )
        {
            IValue result;
            if ( Convert.ToBoolean( value1.Data ) || Convert.ToBoolean( value2.Data ) )
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
