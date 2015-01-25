using System;

namespace ITI.bacASable
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
    

        public SyntaxError(IEngine engine)
        {
            _data = new Object();
            _stackTrace = "";
            //engine.ClashError(this);
        }
        public SyntaxError(IEngine engine, string message)
            : this(engine)
        {
            _message = message;

        }

        public SyntaxError( IEngine engine, ITokenizer t, string message )
            :this(engine, message)
        {
            _line = t.CurrentLine;
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
        
