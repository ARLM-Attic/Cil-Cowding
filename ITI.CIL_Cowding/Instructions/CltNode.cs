﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public class CltNode : BinaryComparatorNode
    {
        protected override IValue Comparator( IValue value1, IValue value2 )
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
