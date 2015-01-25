using System;

namespace ITI.bacASable
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

        public LogicError(IEngine engine)
        {
            _message = "";
            _data = new Object();
            _stackTrace = "";
            _line = 0;
        }
        public LogicError( IEngine engine, string message )
            :this(engine)
        {
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
