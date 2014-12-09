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
    public class BrtrueNode : InstructionNode
    {
        string _label;

        public BrtrueNode(string label)
        {
            _label = label;
        }
        public override void Execute(IExecutionContext ctx)
        {
            throw new NotImplementedException();
        }
    }
}
