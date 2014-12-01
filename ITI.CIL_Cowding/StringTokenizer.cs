using System;
using System.Text;

namespace ITI.CIL_Cowding
{
    public class StringTokenizer : ITokenizer
    {
        string _toParse;
        int _position;
        int _maxPos;
        int _curLine;
        int _curColumn;
        double _doubleValue;
        string _idOrStringValue;
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
            StringBuilder buffer = new StringBuilder();
            if ( IsEnd ) return _currentToken = TokenType.EndOfInput;
            char c = Read();
            while(char.IsWhiteSpace(c))
            {
                if (IsEnd) return _currentToken = TokenType.EndOfInput;
                c = Read();
            }
            while(!char.IsWhiteSpace(c))
            {
                buffer.Append( c );
                Forward();
            }

            string toAnalyze = buffer.ToString();

            switch( toAnalyze )
            {
                case "var":
                    _currentToken = TokenType.Var; break;
                case "nop":
                    _currentToken = TokenType.Nop; break;
                case "ldc":
                    _currentToken = TokenType.Ldc; break;
                case "ldstr":
                    _currentToken = TokenType.Ldstr; break;
                case "stloc":
                     _currentToken = TokenType.Stloc; break;
                case "ldloc":
                    _currentToken = TokenType.Ldloc; break;
                case "ceq":
                    _currentToken = TokenType.Ceq; break;
                case "clt":
                    _currentToken = TokenType.Clt; break;
                case "not":
                    _currentToken = TokenType.Not; break;
                case "or":
                    _currentToken = TokenType.Or; break;
                case "and":
                    _currentToken = TokenType.And; break;
                case "brtrue":
                    _currentToken = TokenType.Brtrue; break;
                case "brfalse":
                    _currentToken = TokenType.Brfalse; break;
                case "br":
                    _currentToken = TokenType.Br; break;
                case "add":
                    _currentToken = TokenType.Add; break;
                case "mul":
                    _currentToken = TokenType.Mul; break;
                case "div":
                    _currentToken = TokenType.Div; break;
                case "Sub":
                    _currentToken = TokenType.Sub; break;
                case "neg":
                    _currentToken = TokenType.Neg; break;
                case "WRITE":
                    _currentToken = TokenType.Write; break;
                case "READ":
                    _currentToken = TokenType.Read; break;
                case "ret":
                    _currentToken = TokenType.Ret; break;

                default:
                    if (char.IsDigit(c))
                    {
                        _currentToken = TokenType.Number;
                        double val = (int)(c - '0');
                        while (!IsEnd && Char.IsDigit(c))
                        {
                            val = val * 10 + (int)(c - '0');
                            Forward();
                        }
                        _doubleValue = val;
                    }
                    else if (Char.IsLetter(c) || c == '_')
                    {
                        _currentToken = TokenType.Identifier;
                        buffer.Append(c);
                        Forward();
                        while (!IsEnd && (Char.IsLetterOrDigit(c = Peek()) || c == '_'))
                        {
                            buffer.Append(c);
                            Forward();
                        }
                        _idOrStringValue = buffer.ToString();
                    }
                    else if (c == '"')
                    {
                        _currentToken = TokenType.String;
                        c = Read();
                        while (!IsEnd && c != '"')
                        {
                            if (IsEnd) _currentToken = TokenType.ErrorUnterminatedString;

                        }
                    }
                    break;
            }
            return _currentToken;
        }

        public bool IsIdentifier( out string id)
        {
            throw new NotImplementedException();
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

        public bool IsVarType(out VarType value)
        {
            throw new NotImplementedException();
        }

        public bool Match( int expectedValue )
        {
            if( _currentToken == TokenType.Number && 
                _doubleValue == Int32.MaxValue && 
                (int)_doubleValue == expectedValue )
            {
                GetNextToken();
                return true;
            }
            return false;
        }

        public bool Match(TokenType t)
        {
            if(_currentToken == t)
            {
                GetNextToken();
                return true;
            }
            return false;
        }
    }
}