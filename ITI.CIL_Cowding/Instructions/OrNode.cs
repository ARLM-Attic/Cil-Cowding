using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// 
    /// </summary>
    public class OrNode : BinaryBooleanOperatorNode
    {
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
