using System;

namespace ITI.CIL_Cowding
{
    public class StringTokenizer : ITokenizer
    {
        string _toParse;
        int _position;
        int _maxPos;
        int _curLine;
        int _curColumn;
        TokenType _currentToken;

        public StringTokenizer()
        {

        }

        public TokenType CurrentToken
        {
            get { return _currentToken; }
        }

        public int CurrentLine
        {
            get { return _curLine; }
        }

        public int CurrentColumn
        {
            get { return _curColumn;  }
        }

        public bool IsWhiteSpace
        {
            get { return _toParse[_position] == ' '; }
        }

        public bool IsEnd
        {
            get { return _position >= _maxPos; }
        }

        public void ForwardToNextLine()
        {
            throw new NotImplementedException();
        }

        public char Read()
        {
            return _toParse[_position++];
        }

        public char Peek()
        {
            return _toParse[_position];
        }

        public void Forward()
        {
            ++_position;
        }

        public TokenType GetNextToken()
        {

            return _currentToken;
        }

        public bool IsInteger(out int value)
        {
            throw new NotImplementedException();
        }

        public bool IsDouble(out double value)
        {
            throw new NotImplementedException();
        }

        public bool IsString(out string value)
        {
            throw new NotImplementedException();
        }
    }
}
