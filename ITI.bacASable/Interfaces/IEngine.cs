using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.bacASable
{
    public interface IEngine
    {
      //  event EventHandler SourceCodeChanged;
        IPreExecutionContext Pec { get; }
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
