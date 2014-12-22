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

        public RunTimeError(IEngine engine)
        {
            _data = new Object();
            _stackTrace = "";
            _line = 0;
            engine.ClashError( this );
        }
        public RunTimeError( IEngine engine, string message )
            : this(engine)
        {
            _message = message;
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
