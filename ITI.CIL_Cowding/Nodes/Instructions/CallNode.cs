﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public class CallNode : InstructionNode
    {
        // Fields

        string _label;

        public CallNode(string label)
        {
            _label = label;
        }

        public override void Execute(IExecutionContext ctx)
        {
 	        throw new NotImplementedException();
        }
    }
}