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
    class RetNode : InstructionNode
    {
        string _label;

        public RetNode(string str)
        {
            _label = str;
        }
        public override void Execute(IExecutionContext ctx)
        {
            throw new NotImplementedException();
        }
    }
}
