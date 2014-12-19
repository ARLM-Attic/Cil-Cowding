using System;

namespace ITI.CIL_Cowding
{
    public class LogicError
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

        public LogicError()
        {
            _message = "";
            _data = new Object();
            _stackTrace = "";
            _line = 0;
        }
        public LogicError(string message)
        {
            _message = message;
            _data = new Object();
            _stackTrace = "";
            _line = 0;
        }
        public void Write()
        {
            Console.WriteLine( "Logic error : " + _message );
        }
    }
}
