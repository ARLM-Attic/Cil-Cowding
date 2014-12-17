using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding.Interfaces
{
    public interface IEngine
    {
        event EventHandler SourceCodeChanged;

        string SourceCode {get; set;}

        //bool IsRunning { get; }

        void Start();

        void NextInstruction();

        void Stop();

        IStack GetStack(IExecutionContext iec);
    }
}
