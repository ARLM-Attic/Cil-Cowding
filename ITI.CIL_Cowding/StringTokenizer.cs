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
                while ( c != '\n' )
                {
                    Read();
                }
                GetNextToken();
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

        // Je touche pas à ça, ça fais peur tout ça :/
        TokenType GetNextToken()
        {
            _buffer = new StringBuilder();
            if ( IsEnd ) return _currentToken = TokenType.EndOfInput;
            char c = Read();
            while ( char.IsWhiteSpace( c ) )
            {
                if ( IsEnd ) return _currentToken = TokenType.EndOfInput;
                c = Read();
            }
            while ( !char.IsWhiteSpace( c ) )
            {
                _buffer.Append( c );
                Forward();
            }

            string toAnalyze = _buffer.ToString();
            #region switch
            switch ( toAnalyze )
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
                    {
                        if ( char.IsDigit( c ) )
                        {
                            _currentToken = TokenType.Number;
                            double val = (int)( c - '0' );
                            while ( !IsEnd && Char.IsDigit( c ) )
                            {
                                val = val * 10 + (int)( c - '0' );
                                Forward();
                            }
                            _doubleValue = val;
                        }
                        else if ( Char.IsLetter( c ) || c == '_' )
                        {
                            _currentToken = TokenType.Identifier;
                            _buffer.Append( c );
                            Forward();
                            while ( !IsEnd && ( Char.IsLetterOrDigit( c = Peek() ) || c == '_' ) )
                            {
                                _buffer.Append( c );
                                Forward();
                            }
                            _idOrStringValue = _buffer.ToString();
                        }
                        else if ( c == '"' )
                        {
                            _currentToken = TokenType.String;
                            c = Read();
                            while ( !IsEnd && c != '"' )
                            {
                                if ( IsEnd ) _currentToken = TokenType.ErrorUnterminatedString;
                                if ( c == '\\' )
                                {
                                    c = Read();
                                    if ( c != '"' )
                                    {
                                        if ( IsEnd ) return _currentToken = TokenType.ErrorUnterminatedString;
                                    }
                                    if ( c == 'r' ) c = '\r';
                                    else if ( c == 'n' ) c = '\n';
                                    else if ( c == 't' ) c = '\t';
                                    else if ( c == 'u' )
                                    {
                                        c = Read();
                                        if ( IsEnd ) return _currentToken = TokenType.ErrorUnterminatedString;
                                        bool atLeastOne = false;
                                        int val = (int)( c - '0' );
                                        while ( !IsEnd && Char.IsDigit( c = Peek() ) )
                                        {
                                            atLeastOne = true;
                                            val = val * 10 + (int)( c - '0' );
                                            Forward();
                                        }
                                        if ( !atLeastOne ) return _currentToken = TokenType.ErrorUnterminatedString;
                                        if ( val >= (int)char.MaxValue ) return _currentToken = TokenType.ErrorInvalidUnicodeInString;
                                        c = (char)val;
                                    }
                                }
                            }
                            _buffer.Append( c );
                            Forward();
                            _idOrStringValue = _buffer.ToString();
                        }
                        else _currentToken = TokenType.Error;
                        break;
                    }
            }
            #endregion switch
            return _currentToken;
        }


        public bool MatchIdentifier( string identifier )
        {
            return identifier == "var";
        }

        // DONE REDOU
        public bool IsIdentifier( out string id )
        {
            bool reponse;
            if ( _currentToken == TokenType.String )
            {
                id = _idOrStringValue;
                reponse = true;
            }
            else
            {
                reponse = false;
                id = "";
            }

            GetNextToken();
            return reponse;
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

        // TO DO
        public bool IsVarType(out CILNetType value)
        {
            // REDOU: C'est à changer
            /*
            if ( value == VarType.Var_Bool || value == VarType.Var_Int || value == VarType.Var_String )
            {
                return true;
            }
             
            return false;
             */
            throw new NotImplementedException();
        }

        //public bool Match( int expectedValue )
        //{
        //    if( _currentToken == TokenType.Number && 
        //        _doubleValue == Int32.MaxValue && 
        //        (int)_doubleValue == expectedValue )
        //    {
        //        GetNextToken();
        //        return true;
        //    }
        //    return false;
        //}

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