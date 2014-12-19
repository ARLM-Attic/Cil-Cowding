using System;

namespace ITI.CIL_Cowding
{
    public class SyntaxError : IError
    {
        object _data;
        string _stackTrace;
        string _message;
        int _line;

        #region Properties
        public string Message 
        { 
            get { return _message; }
        }
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
    

        public SyntaxError()
        {
            _message = "";
            _data = new Object();
            _stackTrace = "";
            _line = 0;
        }
        public SyntaxError(string message)
        {
            _message = message;
            _data = new Object();
            _stackTrace = "";
            _line = 0;
        }

        public SyntaxError(ITokenizer t, string message)
        {
            _line = t.CurrentLine;
            _message = message;
            _data = new Object();
            _stackTrace = "";
        }
        public void Write()
        {
            Console.WriteLine( "Syntax error : " + _message );
        }
        public override string ToString()
        {
            return _message;
        }
    }
}
        
