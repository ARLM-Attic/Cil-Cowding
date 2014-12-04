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
                    body.Add(new StlocNode(varName1));
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

            #region LDSTR
            else if (_tokenizer.MatchIdentifier("ldstr"))
            {
                string txt;
                if (_tokenizer.IsString(out txt)
                    && _tokenizer.Match(TokenType.EndOfLine))
                {
                    body.Add(new LdstrNode(txt));
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
                    && _tokenizer.IsIdentifier(out label)
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
                string label;

                if (_tokenizer.IsIdentifier(out label)
                    && _tokenizer.Match(TokenType.EndOfLine))
                {
                    body.Add(new BrtrueNode(label));
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
                string label;

                if (_tokenizer.IsIdentifier(out label)
                    && _tokenizer.Match(TokenType.EndOfLine))
                {
                    body.Add(new BrfalseNode(label));
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
                string label;

                if (_tokenizer.IsIdentifier(out label)
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
