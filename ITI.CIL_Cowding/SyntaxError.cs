using System;

namespace ITI.CIL_Cowding
{
    public class SyntaxError
    {
        int _line;
        int _column;
        string _message;
        
        public int Line 
        { 
            get { return _line; }
            private set { _line = value; }
        }

        public int Column 
        {
            get { return _column; } 
            private set { _column = value; } 
        }

        public string Message 
        { 
            get { return _message; }
            private set { _message = value; }
        }

        public SyntaxError(string msg)
        {
            _message = msg;
        }

        public SyntaxError(ITokenizer t, string msg)
        {
            Line = t.CurrentLine;
            Column = t.CurrentColumn;
            Message = msg;
        }
    }
}
        
