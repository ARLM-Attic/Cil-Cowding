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
    public class CeqNode : BinaryComparatorNode
    {
        protected override IValue Comparator( IValue value1, IValue value2 )
        {
            IValue result;
            if ( value1.Data == value2.Data )
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
