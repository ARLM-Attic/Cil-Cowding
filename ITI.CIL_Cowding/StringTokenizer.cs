using System;
using System.Text;
using System.Threading;

namespace ITI.CIL_Cowding
{
    public class StringTokenizer : ITokenizer
    {
        string _toParse;
        int _position;
        int _maxPosition;
        int _currentLine;
        int _currentColumn;
        double _doubleValue;
        string _idOrStringValue;
        readonly StringBuilder _buffer;
        TokenType _currentToken;

        public StringTokenizer(string s)
            : this(s, 0, s.Length)
        {
        }

        public StringTokenizer(string s, int startIndex)
            : this(s, startIndex, s.Length)
        {
        }

        public StringTokenizer(string s, int startIndex, int count)
        {
            _currentToken = TokenType.None;
            _toParse = s;
            _position = startIndex;
            _maxPosition = startIndex + count;
            _currentLine = 1;
            _currentColumn = 1;
            _buffer = new StringBuilder();
            _currentLine = 0;

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
            get { return _currentLine; }
        }

        /// <summary>
        /// Gets the value of the identifier or string. Ex. : value of "hello" is hello. Value of "function" is function.
        /// </summary>
        public string GetValueOfId
        {
            get { return _idOrStringValue; }
        }

   /*     public int CurrentColumn
        /// Gets the current column.
        /// </summary>
        {
            get { return _currentColumn; }
        }
        */
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
            get { return _position >= _maxPosition; }
        }

        /// <summary>
        /// Goes to the next line of the source code.
        /// </summary>
        public void ForwardToNextLine()
        {
            if (!IsEnd)
            {
                char c;
                do
                {
                    c = Read();
                } while (c != '\n' && c != ';');
                ++_currentLine;
                _currentColumn = 1;
                if (!IsEnd) GetNextToken();
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
            try
            {
                return _toParse[_position++];
            }
            catch (Exception e)
            {
                Console.WriteLine( "Error on Tokenizer.Read(). " + e.ToString() );
                Thread.CurrentThread.Abort();
                return '1';
            }
            
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
            _buffer.Clear();
            if (IsEnd) return _currentToken = TokenType.EndOfInput;
            char c = Read();
            if (c == '\n')
            {
                ++_currentLine;
                _currentColumn = 1;
            }
            _currentColumn++;
            while (char.IsWhiteSpace(c))
            {
                c = Read();
                if (c == '\n')
                {
                    _currentLine++;
                    _currentColumn = 1;
                }
                _currentColumn++;
                if (IsEnd) return _currentToken = TokenType.EndOfInput;
            }

            switch (c)
            {
                // Terminal chars
                case '-': _currentToken = TokenType.Minus; break;
                case '(': _currentToken = TokenType.OpenPar; break;
                case ')': _currentToken = TokenType.ClosedPar; break;
                case '[': _currentToken = TokenType.OpenBracket; break;
                case ']': _currentToken = TokenType.ClosedBracket; break;
                case '{': _currentToken = TokenType.OpenCurly; break;
                case '}': _currentToken = TokenType.ClosedCurly; break;
                case '.': _currentToken = TokenType.Dot; break;
                case ';': _currentToken = TokenType.SemiColon; break;
                case ',': _currentToken = TokenType.Comma; break;
                case '#': _currentToken = TokenType.HashTag; break;
                case ':':
                    {
                        if (!IsEnd && Peek() == ':')
                        {
                            Forward();
                            _currentColumn++;
                            _currentToken = TokenType.DoubleColon;
                        }
                        else _currentToken = TokenType.Colon;
                        break;
                    }
                case '/':
                    {
                        if (IsEnd) _currentToken = TokenType.Error;
                        else
                        {
                            c = Peek();
                            if (c == '/') // Slash Comments 
                            {
                                ForwardToNextLine();
                            }
                            else if (c == '*') // Block Comments
                            {
                                #region block comments
                                Forward();
                                _currentColumn++;
                                while (!IsEnd)
                                {
                                    if (Peek() == '*')
                                    {
                                        Forward();
                                        _currentColumn++;
                                        if (Peek() == '/')
                                        {
                                            Forward();
                                            _currentColumn++;
                                            break;
                                        }
                                    }
                                    else Forward();
                                    _currentColumn++;
                                }
                                #endregion block comments
                                return GetNextToken();
                            }
                            else _currentToken = TokenType.Error;
                        }
                        break;
                    }
                default:
                    // We look if the thing that we are receiving is a number
                    if ( char.IsDigit( c ) )
                    {
                        #region Number
                        _currentToken = TokenType.Number;
                        double val = (int)(c - '0');
                        while (!IsEnd && Char.IsDigit((c = Peek())))
                        {
                            val = val * 10 + (int)(c - '0');
                            Forward();
                            _currentColumn++;
                        }

                        if (c == ',')
                        {
                            _buffer.Append('0');
                            _buffer.Append(c);
                            Forward();
                            while (!IsEnd && Char.IsDigit(c = Peek()))
                            {
                                _buffer.Append(c);
                                Forward();
                            }

                            _idOrStringValue = _buffer.ToString();
                            double tmp = Convert.ToDouble(_idOrStringValue);
                            _doubleValue = (double)val + tmp;
                        }
                        else
                        {
                            _doubleValue = val;
                        }
                        #endregion Number
                    }
                    // Else look if the thing that we are receiving is a letter or _, then it's an identifier
                    else if (Char.IsLetter(c) || c == '_')
                    {
                        #region Identifier
                        _currentToken = TokenType.Identifier;
                        _buffer.Append(c);
                        while (!IsEnd && (Char.IsLetterOrDigit(c = Peek()) || c == '_'))
                        {
                            _buffer.Append(c);
                            Forward();
                            _currentColumn++;
                        }
                        _idOrStringValue = _buffer.ToString();
                        #endregion Identifier
                    }
                    // We look if the thing that we are receiving is a string
                    else if (c == '"')
                    {
                        #region String
                        _currentToken = TokenType.String;
                        while (!IsEnd && (c = Peek()) != '"')
                        {
                            if (c == '\\')
                            {
                                c = Read();
                                _currentColumn++;
                                if (IsEnd) return _currentToken = TokenType.ErrorUnterminatedString;
                                if (c == 'r') c = '\r';
                                else if (c == 'n')
                                {
                                    c = '\n';
                                    ++_currentLine;
                                    _currentColumn = 1;
                                }
                                else if (c == 't') c = '\t';
                                else if (c == 'u')
                                {
                                    c = Read();
                                    _currentColumn++;
                                    if (IsEnd) return _currentToken = TokenType.ErrorUnterminatedString;
                                    bool atLeastOne = false;
                                    int val = (int)(c - '0');
                                    while (!IsEnd && Char.IsDigit(c = Peek()))
                                    {
                                        atLeastOne = true;
                                        val = val * 10 + (int)(c - '0');
                                        Forward();
                                        _currentColumn++;
                                    }
                                    if (!atLeastOne) return _currentToken = TokenType.ErrorUnterminatedString;
                                    if (val >= (int)char.MaxValue) return _currentToken = TokenType.ErrorInvalidUnicodeInString;
                                    c = (char)val;
                                }
                            }
                            else Forward();
                            _currentColumn++;
                            _buffer.Append(c);
                        }
                        if (IsEnd) return _currentToken = TokenType.ErrorUnterminatedString;
                        Forward();
                        _currentColumn++;
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
        public bool MatchIdentifier(string identifier)
        {
            if (_currentToken == TokenType.Identifier && _idOrStringValue == identifier)
            {
                GetNextToken();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Tests if we have an identifier and gives it's value.
        /// </summary>
        /// <param name="id">The value of the identifier.</param>
        /// <returns></returns>
        public bool IsIdentifier(out string id)
        {
            if (_currentToken == TokenType.Identifier)
            {
                id = _idOrStringValue;
                GetNextToken();
                return true;
            }
            id = null;
            return false;
        }

        /// <summary>
        /// Tests if we have a number as a token and gives it's value.
        /// </summary>
        /// <param name="value">The value of the integer</param>
        /// <returns>True if we have a Type "number" as a token.</returns>
        public bool IsInteger(out int value)
        {
            if (_currentToken == TokenType.Number)
            {
                value = (int)_doubleValue;
                GetNextToken();
                return true;
            }
            value = 0;
            return false;
        }

        /// <summary>
        /// Tests if we have a number as a token and gives it's value.
        /// </summary>
        /// <param name="value">The value of the double.</param>
        /// <returns>True if we have a type "number" as a token.</returns>
        public bool IsDouble(out double value)
        {
            if (_currentToken == TokenType.Number)
            {
                value = _doubleValue;
                GetNextToken();
                return true;
            }
            value = 0;
            return false;
        }

        /// <summary>
        /// Tests if we have a string a token type and gives it's value.
        /// </summary>
        /// <param name="value">value of the string.</param>
        /// <returns>True if we have a string and affects it's value to <paramref name="value"/>.</returns>
        public bool IsString(out string value)
        {
            if (_currentToken == TokenType.String)
            {
                value = _idOrStringValue;
                GetNextToken();
                return true;
            }
            value = null;
            return false;
        }

        /// <summary>
        /// Tests if we have the right token type of the current token.
        /// </summary>
        /// <param name="t">The token type given.</param>
        /// <returns>True if the token type given is the same as the current token.</returns>
        public bool Match(TokenType t)
        {
            if (_currentToken == t)
            {
                GetNextToken();
                return true;
            }
            return false;
        }
    }
}