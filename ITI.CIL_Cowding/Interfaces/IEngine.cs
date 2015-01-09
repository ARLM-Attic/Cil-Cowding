using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public interface IEngine
    {
      //  event EventHandler SourceCodeChanged;

        string SourceCode {get; set;}

        bool IsRunning { get; }

        int Start();

        bool NextInstruction();

        void Stop();
        void ClashError(IError error);
        void ClashError( List<IError> error );

        IStack GetStack();

    }
}
