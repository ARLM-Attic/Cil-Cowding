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
        StringBuilder _buffer;
        TokenType _currentToken;

        public StringTokenizer( string s )
        : this( s, 0, s.Length )
        {
        }

        public StringTokenizer(string s, int startIndex)
            : this(s, startIndex, s.Length)
        {
        }



        public StringTokenizer( string s, int startIndex, int count )
        {
            _currentToken = TokenType.None;
            _toParse = s;
            _position = startIndex;
            _maxPos = startIndex + count;

            GetNextToken();

        }


        public TokenType CurrentToken
        {
            get { return _currentToken; }
        }

        public int CurrentLine
        {
            get { return _curLine; }
        }

        public string GetValueOfId
        {
            get { return _idOrStringValue; }
        }

        public int CurrentColumn
        {
            get { return _curColumn; }
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
            if ( !IsEnd )
            {
                char c = Read();
                while ( c != ';' && !IsEnd )
                {
                    Read();
                }
                if (!IsEnd) { GetNextToken(); }
                else { }
                
            }
            else
            {
                // NOP
            }
        }

        char Read()
        {
            return _toParse[_position++];
        }

        char Peek()
        {
            return _toParse[_position];
        }

        void Forward()
        {
            ++_position;
        }

        public TokenType GetNextToken()
        {
            _buffer = new StringBuilder();
            if ( IsEnd ) return _currentToken = TokenType.EndOfInput;
            char c = Read();
            while ( char.IsWhiteSpace( c ) )
            {
                if ( IsEnd ) return _currentToken = TokenType.EndOfInput;
                c = Read();
            }

            switch(c)
            {
                // Terminal chars
                case '-': _currentToken = TokenType.Minus; break;
                case '(': _currentToken = TokenType.OpenPar; break;
                case ')': _currentToken = TokenType.ClosedPar; break;
                case '[': _currentToken = TokenType.OpenBracket ; break;
                case ']': _currentToken = TokenType.ClosedBracket ; break;
                case '{': _currentToken = TokenType.OpenCurly ; break;
                case '}': _currentToken = TokenType.ClosedCurly; break;
                case '.': _currentToken = TokenType.Dot; break;
                case ':': _currentToken = TokenType.Colon; break;
                case ';': _currentToken = TokenType.SemiColon; break;

                default:
                    // We look if the thing that we are receiving is a number
                    if (char.IsDigit(c))
                    #region Number

                    {
                        _currentToken = TokenType.Number;
                        double val = (int)(c - '0');
                        while (!IsEnd && Char.IsDigit(_toParse[_position]))
                        {
                            val = val * 10 + (int)(c - '0');
                            Forward();
                        }
                        _doubleValue = val;
                    }
                    #endregion number
                    // Else look if the thing that we are receiving is a letter
                    else if (Char.IsLetter(c) || c == '_')
                    #region Letter
                    {
                        _currentToken = TokenType.Identifier;
                        _buffer.Append(c);
                        //Forward();
                        while (!IsEnd && (Char.IsLetterOrDigit( c=Peek() ) || c == '_'))
                        {
                            _buffer.Append(c);
                            Forward();
                        }

                        _idOrStringValue = _buffer.ToString();

                    }
                    #endregion Letter
                    // We look if the thing that we are receiving is a string
                    else if (c == '"')
                    #region String

                    {
                        _currentToken = TokenType.String;
                        c = Read();
                        while (!IsEnd && c != '"')
                        {
                            if ( IsEnd ) _currentToken = TokenType.ErrorUnterminatedString;
                            if (c == '\\')
                            {
                                c = Read();
                                if (c != '"')
                                {
                                    if (IsEnd) return _currentToken = TokenType.ErrorUnterminatedString;
                                }
                                if (c == 'r') c = '\r';
                                else if (c == 'n') c = '\n';
                                else if (c == 't') c = '\t';
                                else if (c == 'u')
                                {
                                    c = Read();
                                    if (IsEnd) return _currentToken = TokenType.ErrorUnterminatedString;
                                    bool atLeastOne = false;
                                    int val = (int)(c - '0');
                                    while (!IsEnd && Char.IsDigit(c = Peek()))
                                    {
                                        atLeastOne = true;
                                        val = val * 10 + (int)(c - '0');
                                        Forward();
                                    }
                                    if (!atLeastOne) return _currentToken = TokenType.ErrorUnterminatedString;
                                    if (val >= (int)char.MaxValue) return _currentToken = TokenType.ErrorInvalidUnicodeInString;
                                    c = (char)val;
                                }
                            }
                        }
                        _buffer.Append(c);
                        Forward();
                        _idOrStringValue = _buffer.ToString();
                    }
                    #endregion String
                    // Else, Error...
                    else _currentToken = TokenType.Error;
                    break;

            }        
            return _currentToken;
        }


        public bool MatchIdentifier( string identifier )
        {
            if( _currentToken == TokenType.Identifier && _idOrStringValue == identifier )
            {
                GetNextToken();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsIdentifier( out string id )
        {
            if (_currentToken == TokenType.Identifier)
            {
                id = _idOrStringValue;
                GetNextToken();
                return true;
            }
            else
            {
                id = "";
                GetNextToken();
                return false;
            }
        }

        // DONE REDOU
        public bool IsInteger( out int value )
        {
            bool reponse;
            if ( _currentToken == TokenType.Number )
            {
                value = (int)_doubleValue;
                reponse = true;
            }
            else
            {
                reponse = false;
                value = 0;
            }

            GetNextToken();
            return reponse;

        }

        // DONE REDOU
        public bool IsDouble( out double value )
        {
            bool reponse;
            if ( _currentToken == TokenType.Number )
            {
                value = _doubleValue;
                reponse = true;
            }
            else
            {
                reponse = false;
                value = 0;
            }

            GetNextToken();
            return reponse;
        }

        // DONE REDOU
        public bool IsString( out string value )
        {
            bool reponse;
            if ( _currentToken == TokenType.String )
            {
                value = _idOrStringValue;
                reponse = true;
            }
            else
            {
                reponse = false;
                value = "";
            }

            GetNextToken();
            return reponse;
        }

        // DONE
        public bool Match( TokenType t )
        {
            if ( _currentToken == t )
            {
                GetNextToken();
                return true;
            }
            return false;
        }
    }
}