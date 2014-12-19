using System;

namespace ITI.CIL_Cowding
{
    public class RunTimeError : IError
    {
        object _data;
        string _stackTrace;
        string _message;
        int _line;
        #region Properties
        public int Line
        {
            get { return _line; }
        }
        public object Data
        {
            get { return _data; }
        }
        public string StackTrace
        {
            get { return _stackTrace; }
        }
        #endregion

        public RunTimeError()
        {
            _message = "";
            _data = new Object();
            _stackTrace = "";
            _line = 0;
        }
        public RunTimeError(string message)
        {
            _message = message;
            _data = new Object();
            _stackTrace = "";
            _line = 0;
        }

        public override string ToString()
        {
            return _message;
        }
        public void Write()
        {
            Console.WriteLine( "RunTime error : " + _message );
        }
    }
}
