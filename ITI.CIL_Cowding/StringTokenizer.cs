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
            
            // Beginning
            GetNextToken();
        }

        /// <summary>
        /// Gets the current token.
        /// </summary>
        public TokenType CurrentToken
        {
            get { return _currentToken; }
        }

        /// <summary>
        /// Gets the current line in execution.
        /// </summary>
        public int CurrentLine
        {
            get { return _curLine; }
        }

        /// <summary>
        /// Gets the value of the identifier or string. Ex. : value of "hello" is hello. Value of "function" is function.
        /// </summary>
        public string GetValueOfId
        {
            get { return _idOrStringValue; }
        }

        /// <summary>
        /// Gets the current column.
        /// </summary>
        public int CurrentColumn
        {
            get { return _curColumn; }
        }

        /// <summary>
        /// Tests if the current character is a white space.
        /// </summary>
        public bool IsWhiteSpace
        {
            get { return _toParse[_position] == ' '; }
        }

        /// <summary>
        /// Tests if we are at the end of all the string given.
        /// </summary>
        public bool IsEnd
        {
            get { return _position >= _maxPos; }
        }

        /// <summary>
        /// Goes to the next line of the source code.
        /// </summary>
        public void ForwardToNextLine()
        {
            if ( !IsEnd )
            {
                char c;
                do {
                    c = Read();
                } while( c != '\n' && c != ';' );

                if( !IsEnd ) GetNextToken();
            }
            else
            {
                // NOP
            }
        }

        /// <summary>
        /// Reads the current character and ups the head reader.
        /// </summary>
        /// <returns>The current character and ups.</returns>
        char Read()
        {
            return _toParse[_position++];
        }

        /// <summary>
        /// Only reads the current char.
        /// </summary>
        /// <returns>The current character.</returns>
        char Peek()
        {
            return _toParse[_position];
        }

        /// <summary>
        /// Ups the head reader.
        /// </summary>
        void Forward()
        {
            ++_position;
        }

        /// <summary>
        /// Gives the next token.
        /// </summary>
        /// <returns>The new current token.</returns>
        public TokenType GetNextToken()
        {
            _buffer = new StringBuilder();
            if ( IsEnd ) return _currentToken = TokenType.EndOfInput;
            char c = Peek(); // previously Read()
            while ( char.IsWhiteSpace( c ) )
            {
                if ( IsEnd ) return _currentToken = TokenType.EndOfInput;
                c = Read();
            }

            switch( c )
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
                case ':':
                    {
                        if( !IsEnd && Peek() == ':' )
                        {
                            Forward();
                            _currentToken = TokenType.DoubleColon;
                        }
                        else _currentToken = TokenType.Colon;
                        break;
                    }
                case ';': _currentToken = TokenType.SemiColon; break;
                case ',': _currentToken = TokenType.Comma; break;
                case '/':
                    {
                        if (!IsEnd && Peek() == '/') // Slash Comments 
                        {
                            #region comments double slash
                            ForwardToNextLine();
                            #endregion comments double slash
                        }
                        else if (Peek() == '*') // Block Comments
                        {
                            #region block comments
                            Forward();
                            while (Peek() != '*' && Read() != '/')
                            {
                                Forward();
                            }
                            if (!IsEnd)
                            {
                                GetNextToken();
                            }
                            else
                            {
                                // NOP
                            }
                            #endregion block comments
                        }
                        break;
                    }
                case '#': _currentToken = TokenType.HashTag; break;
                default:
                    // We look if the thing that we are receiving is a number
                    if (char.IsDigit(c))
                    {
                        #region Number
                        _currentToken = TokenType.Number;
                        double val = (int)(c - '0');
                        while (!IsEnd && Char.IsDigit(_toParse[_position]))
                        {
                            val = val * 10 + (int)(c - '0');
                            Forward();
                        }
                        _doubleValue = val;
                        #endregion Number
                    }
                    // Else look if the thing that we are receiving is a letter or _, then it's an identifier
                    else if (Char.IsLetter(c) || c == '_')
                    {
                        #region Identifier
                        _currentToken = TokenType.Identifier;
                        _buffer.Append(c);
                        Forward(); // not previously
                        while (!IsEnd && (Char.IsLetterOrDigit( c = Peek() ) || c == '_'))
                        {
                            _buffer.Append(c);
                            Forward();
                        }
                        _idOrStringValue = _buffer.ToString();
                        GetNextToken();
                        #endregion Identifier
                    }
                    // We look if the thing that we are receiving is a string
                    else if (c == '\"')
                    {
                        #region String
                        _currentToken = TokenType.String;
                        c = Peek(); 
                        while ( !IsEnd /* && c != '\"' */  )
                        {
                            string strTemp = _buffer.ToString();
                            if (strTemp == "\"\"")
                            {
                                //_buffer.Clear();
                                //_idOrStringValue = _buffer.ToString();
                                GetNextToken();
                                _buffer.Clear();
                                _idOrStringValue = _buffer.ToString();
                                /*if (IsEnd)*/ return _currentToken;
                            }
                            if ( IsEnd ) _currentToken = TokenType.ErrorUnterminatedString;
                            if (c == '\\')
                            {
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
                            c = Read();
                           // if (IsEnd) return _currentToken = TokenType.ErrorUnterminatedString;
                            if (c == '\"')
                            {
                                char temp = c;
                                if( Char.IsLetterOrDigit( c = Peek() ) || c != ' ' )
                                {
                                    _buffer.Append( temp );
                                    Forward();
                                }
                                else
                                {
                                    return _currentToken;
                                }                                
                            }
                            _buffer.Append(c);
                            _idOrStringValue = _buffer.ToString();
                        }
                        Forward();
                        _idOrStringValue = _buffer.ToString();
                        #endregion String
                    }
                    // Else, Error...
                    else _currentToken = TokenType.Error;
                    break;

            }        
            return _currentToken;
        }

        /// <summary>
        /// Tests if the token is an identifier and we have it's right value.
        /// </summary>
        /// <param name="identifier">The value of the identifier</param>
        /// <returns>True if the value of the identifier is the the same getted.</returns>
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

        /// <summary>
        /// Tests if we have an identifier and gives it's value.
        /// </summary>
        /// <param name="id">The value of the identifier.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Tests if we have a number as a token and gives it's value.
        /// </summary>
        /// <param name="value">The value of the integer</param>
        /// <returns>True if we have a Type "number" as a token.</returns>
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

        /// <summary>
        /// Tests if we have a number as a token and gives it's value.
        /// </summary>
        /// <param name="value">The value of the double.</param>
        /// <returns>True if we have a type "number" as a token.</returns>
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

        /// <summary>
        /// Tests if we have a string a token type and gives it's value.
        /// </summary>
        /// <param name="value">value of the string.</param>
        /// <returns>True if we have a string and affects it's value to <paramref name="value"/>.</returns>
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

        /// <summary>
        /// Tests if we have the right token type of the current token.
        /// </summary>
        /// <param name="t">The token type given.</param>
        /// <returns>True if the token type given is the same as the current token.</returns>
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