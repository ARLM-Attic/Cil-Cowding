using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{

    class Analyzer
    {

        ITokenizer _tokenizer;
        List<SyntaxError> _errors;



        public Analyzer(ITokenizer tokenizer)
        {
            _tokenizer = tokenizer;
        }

        List<InstructionNode> ParseBody()
        {

            List<InstructionNode> body = new List<InstructionNode>();

            /*
            #region TEMPLATE
            else if (_tokenizer.MatchIdentifier("XXX"))
            {
                // VAR

                if (_tokenizer.IsInteger(out constante)
                    && _tokenizer.Match(TokenType.EndOfLine))
                {
                    body.Add(new XXXNode(var));
                }
                else
                {
                    AddError("Error message");
                    _tokenizer.ForwardToNextLine();
                }
            }
            #endregion
            */

            #region STLOC
            if (_tokenizer.MatchIdentifier("stloc"))
            {
                string varName1;

                if (_tokenizer.IsIdentifier(out varName1)
                    && _tokenizer.Match(TokenType.EndOfLine))
                {
                    body.Add(new StLocNode(varName1));
                }
                else
                {
                    AddError("Local variable name expected.");
                    _tokenizer.ForwardToNextLine();
                }
            }
            #endregion STLOC

            #region LDC
            else if (_tokenizer.MatchIdentifier("ldc"))
            {
                int constante;
                if(_tokenizer.IsInteger(out constante)
                    && _tokenizer.Match(TokenType.EndOfLine)) {
                        body.Add(new LdcNode(constante));
                }
                else
                {
                    AddError("Ldc need constante value");
                    _tokenizer.ForwardToNextLine();
                }
            }
            #endregion
            
            #region VAR
            else if (_tokenizer.MatchIdentifier("var"))
            {
                // VAR
                string label;
                VarType vartype;

                if (_tokenizer.IsVarType(out vartype)
                    && _tokenizer.IsLabel(out label)
                    && _tokenizer.Match(TokenType.EndOfLine))
                {
                    body.Add(new VarNode(vartype, label));
                }
                else
                {
                    AddError("Can't create the variable");
                    _tokenizer.ForwardToNextLine();
                }
            }
            #endregion

            #region NOP
            else if (_tokenizer.MatchIdentifier("nop"))
            {
                if (_tokenizer.Match(TokenType.EndOfLine))
                {
                    body.Add(new NopNode());
                }
                else
                {
                    AddError("Nop WHAT ?!");
                    _tokenizer.ForwardToNextLine();
                }
            }
            #endregion

            #region CEQ
            else if (_tokenizer.MatchIdentifier("ceq"))
            {                

                if ( _tokenizer.Match(TokenType.EndOfLine) )
                {
                    body.Add(new CeqNode());
                }
                else
                {
                    AddError("Error syntax with CEQ");
                    _tokenizer.ForwardToNextLine();
                }
            }
            #endregion

            #region CGT
            else if (_tokenizer.MatchIdentifier("cgt"))
            {                

                if ( _tokenizer.Match(TokenType.EndOfLine) )
                {
                    body.Add(new CgtNode());
                }
                else
                {
                    AddError("Error syntax with CGT");
                    _tokenizer.ForwardToNextLine();
                }
            }
            #endregion
            
            #region CLT
            else if (_tokenizer.MatchIdentifier("clt"))
            {                

                if ( _tokenizer.Match(TokenType.EndOfLine) )
                {
                    body.Add(new CltNode());
                }
                else
                {
                    AddError("Error syntax with CLT");
                    _tokenizer.ForwardToNextLine();
                }
            }
            #endregion

            #region NOT
            else if (_tokenizer.MatchIdentifier("not"))
            {                

                if ( _tokenizer.Match(TokenType.EndOfLine) )
                {
                    body.Add(new NotNode());
                }
                else
                {
                    AddError("Error syntax with NOT");
                    _tokenizer.ForwardToNextLine();
                }
            }
            #endregion

            #region OR
            else if (_tokenizer.MatchIdentifier("or"))
            {                

                if ( _tokenizer.Match(TokenType.EndOfLine) )
                {
                    body.Add(new OrNode());
                }
                else
                {
                    AddError("Error syntax with OR");
                    _tokenizer.ForwardToNextLine();
                }
            }
            #endregion

            #region AND
            else if (_tokenizer.MatchIdentifier("and"))
            {                

                if ( _tokenizer.Match(TokenType.EndOfLine) )
                {
                    body.Add(new AndNode());
                }
                else
                {
                    AddError("Error syntax with And");
                    _tokenizer.ForwardToNextLine();
                }
            }
            #endregion

            #region BRTRUE
            else if (_tokenizer.MatchIdentifier("brtrue"))
            {
                // VAR
                Label label;

                if (_tokenizer.IsLabel(out label)
                    && _tokenizer.Match(TokenType.EndOfLine))
                {
                    body.Add(new BrTrueNode(label));
                }
                else
                {
                    AddError("label of br expected");
                    _tokenizer.ForwardToNextLine();
                }
            }
            #endregion

            #region BRFALSE
            else if (_tokenizer.MatchIdentifier("brfalse"))
            {
                // VAR
                Label label;

                if (_tokenizer.IsLabel(out label)
                    && _tokenizer.Match(TokenType.EndOfLine))
                {
                    body.Add(new BrFalseNode(label));
                }
                else
                {
                    AddError("label of br expected");
                    _tokenizer.ForwardToNextLine();
                }
            }
            #endregion

            #region BR
            else if (_tokenizer.MatchIdentifier("br"))
            {
                // VAR
                Label label;

                if (_tokenizer.IsLabel(out label)
                    && _tokenizer.Match(TokenType.EndOfLine))
                {
                    body.Add(new BrNode(label));
                }
                else
                {
                    AddError("label of br expected");
                    _tokenizer.ForwardToNextLine();
                }
            }
            #endregion

            #region ADD
            else if (_tokenizer.MatchIdentifier("add"))
            {
                // VAR
                

                if ( _tokenizer.Match(TokenType.EndOfLine) )
                {
                    body.Add(new AddNode());
                }
                else
                {
                    AddError("How can you have an error with add ??");
                    _tokenizer.ForwardToNextLine();
                }
            }
            #endregion

            #region MUL
            else if (_tokenizer.MatchIdentifier("mul"))
            {
                // VAR


                if (_tokenizer.Match(TokenType.EndOfLine))
                {
                    body.Add(new MulNode());
                }
                else
                {
                    AddError("How can you have an error with mul ??");
                    _tokenizer.ForwardToNextLine();
                }
            }
            #endregion

            #region DIV
            else if (_tokenizer.MatchIdentifier("div"))
            {
                // VAR


                if (_tokenizer.Match(TokenType.EndOfLine))
                {
                    body.Add(new DivNode());
                }
                else
                {
                    AddError("How can you have an error with div ??");
                    _tokenizer.ForwardToNextLine();
                }
            }
            #endregion

            #region SUB
            else if (_tokenizer.MatchIdentifier("sub"))
            {
                // VAR


                if (_tokenizer.Match(TokenType.EndOfLine))
                {
                    body.Add(new SubNode());
                }
                else
                {
                    AddError("How can you have an error with sub ??");
                    _tokenizer.ForwardToNextLine();
                }
            }
            #endregion

            #region NEG
            else if (_tokenizer.MatchIdentifier("neg"))
            {
                // VAR


                if (_tokenizer.Match(TokenType.EndOfLine))
                {
                    body.Add(new NegNode());
                }
                else
                {
                    AddError("How can you have an error with neg ??");
                    _tokenizer.ForwardToNextLine();
                }
            }
            #endregion

            #region WRITE
            else if (_tokenizer.MatchIdentifier("write"))
            {
                // VAR


                if (_tokenizer.Match(TokenType.EndOfLine))
                {
                    body.Add(new WriteNode());
                }
                else
                {
                    AddError("How can you have an error with write ??");
                    _tokenizer.ForwardToNextLine();
                }
            }
            #endregion

            #region READ
            else if (_tokenizer.MatchIdentifier("read"))
            {
                // VAR


                if (_tokenizer.Match(TokenType.EndOfLine))
                {
                    body.Add(new ReadNode());
                }
                else
                {
                    AddError("How can you have an error with read ??");
                    _tokenizer.ForwardToNextLine();
                }
            }
            #endregion

            #region RET
            else if (_tokenizer.MatchIdentifier("ret"))
            {
                // VAR


                if (_tokenizer.Match(TokenType.EndOfLine))
                {
                    body.Add(new RetNode());
                }
                else
                {
                    AddError("How can you have an error with Ret ??");
                    _tokenizer.ForwardToNextLine();
                }
            }
            #endregion


        }

        private void AddError(string msg) {
            _errors.Add(new SyntaxError(msg));
        }


    }
}


/*


 

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

 

namespace Parsing

{

    interface ITokenizer

    {

        bool MatchIdentifier( string expectedId );

        bool IsIdentifier( out string identifier );

        int CurrentLine { get; }

        int CurrentColumn { get; }

        void ForwardToNextLine();

    }

 

    interface IExecutionContext

    {

        IStack Stack { get; }

        IHeap Heap { get; }

    }

 

    interface IStack

    {

    }

   

    interface IHeap

    {

    }

 

    abstract class InstructionNode

    {

 

        public abstract void Execute( IExecutionContext ctx );

    }

 

    class StLocNode : InstructionNode

    {

        public string VariableName { get; private set; }

 

        public StLocNode( string varName )

        {

            VariableName = varName;

        }

    }

 

    class FunctionNode

    {

        public string Name { get; }

        public List<InstructionNode> Body { get; }

    }

 

 

    class SyntaxError

    {

        public int Line { get; private set; }

 

        public int Column { get; private set; }

 

        public string Message { get; private set; }

 

        public SyntaxError( ITokenizer t, string message )

        {

            Line = t.CurrentLine;

            Column = t.CurrentColumn;

            Message = message;

        }

    }

 

    class Analyser

    {

 

        ITokenizer _tokenizer;

        List<SyntaxError> _errors;

 

        public Analyser( ITokenizer tokenizer )

        {

            _tokenizer = tokenizer;

        }

 

        List<InstructionNode> ParseBody()

        {

            List<InstructionNode> body = new List<InstructionNode>();

            if( _tokenizer.MatchIdentifier( "stloc" ) )

            {

                string varName1, varName2;

                int num;

                if( _tokenizer.IsIdentifier( out varName1 )

                    && _tokenizer.Match( TokenType.Comma )

                    && _tokenizer.IsIdentifier( out varName2 )

                    && _tokenizer.Match( TokenType.Comma )

                    && _tokenizer.IsInteger( out num ) )

                {

                    body.Add( new StLocNode( varName1, varName2, num ) );

                }

                else

                {

                    AddError( "Local variable name expected." );

                    _tokenizer.ForwardToNextLine();

                }

            }

            else if( _tokenizer.MatchIdentifier( "ldc" ) )

            {

 

            }

        }

 

        private void AddError( string msg )

        {

            _errors.Add( new SyntaxError( _tokenizer, msg ) );

        }

 

    }

 

}

 

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// :

            public TokenType GetNextToken()

            {

                if( IsEnd ) return _curToken = TokenType.EndOfInput;

                char c = Read();

                while( Char.IsWhiteSpace( c ) )

                {

                    if( IsEnd ) return _curToken = TokenType.EndOfInput;

                    c = Read();

                }

                switch( c )

                {

                    case '+': _curToken = TokenType.Plus; break;

                    case '-': _curToken = TokenType.Minus; break;

                    case '*': _curToken = TokenType.Mult; break;

                    case '/': _curToken = TokenType.Div; break;

                    case '(': _curToken = TokenType.OpenPar; break;

                    case ')': _curToken = TokenType.ClosePar; break;

                    case '?': _curToken = TokenType.QuestionMark; break;

                    case ':': _curToken = TokenType.Colon; break;

                    default:

                        {

                            if( Char.IsDigit( c ) )

                            {

                                _curToken = TokenType.Number;

                                double val = (int)(c - '0');

                                while( !IsEnd && Char.IsDigit( c = Peek() ) )

                                {

                                    val = val * 10 + (int)(c - '0');

                                    Forward();

                                }

                                _doubleValue = val;

                            }

                            else if( Char.IsLetter( c ) || c == '_' )

                            {

                                _curToken = TokenType.Identifier;

                                StringBuilder buffer = new StringBuilder();

                                buffer.Append( c );

                                while( !IsEnd && (Char.IsLetterOrDigit( c = Peek() ) || c == '_') )

                                {

                                    buffer.Append( c );

                                    Forward();

                                }

                                _idOrStringValue = buffer.ToString();

                            }

                            else if( c == '"' )

                            {

                                _curToken = TokenType.String;

                                StringBuilder buffer = new StringBuilder();

                                c = Read();

                                while( !IsEnd && c != '"' )

                                {

                                    if( IsEnd ) return _curToken = TokenType.ErrorUnterminatedString;

                                    if( c == '\\' )

                                    {

                                        c = Read();

                                        if( c != '"' )

                                        {

                                            if( IsEnd ) return _curToken = TokenType.ErrorUnterminatedString;

                                            if( c == 'r' ) c = '\r';

                                            else if( c == 'n' ) c = '\n';

                                            else if( c == 't' ) c = '\t';

                                            else if( c == 'u' )

                                            {

                                                c = Read();

                                                if( IsEnd ) return _curToken = TokenType.ErrorUnterminatedString;

                                                bool atLeastOne = false;

                                                int val = (int)(c - '0');

                                                while( !IsEnd && Char.IsDigit( c = Peek() ) )

                                                {

                                                    atLeastOne = true;

                                                    val = val * 10 + (int)(c - '0');

                                                    Forward();

                                                }

                                                if( !atLeastOne ) return _curToken = TokenType.ErrorUnterminatedString;

                                                if( val >= (int)char.MaxValue ) return _curToken = TokenType.ErrorInvalidUnicodeInString;

                                                c = (char)val;

                                            }

                                        }

                                    }

                                    buffer.Append( c );

                                    Forward();

                                }

                                _idOrStringValue = buffer.ToString();

                            }

 

                            }

                            else _curToken = TokenType.Error;

                            break;

                        }

                }

                return _curToken;

            }

 



*/