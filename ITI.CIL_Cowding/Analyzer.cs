using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public class Analyzer
    {

        ITokenizer _tokenizer;
        List<SyntaxError> _errors;

        public Analyzer(ITokenizer tokenizer)
        {
            _tokenizer = tokenizer;
            _errors = new List<SyntaxError>();
        }

        public List<FunctionNode> ParseBody()
        {

            List<FunctionNode> methods = new List<FunctionNode>();
            //List<FieldDeclarartionNode> methods = new List<FieldDeclarartionNode>();

            while (!_tokenizer.IsEnd)
            {
                #region TEMPLATE
                /*
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
            */
                #endregion

                FunctionNode f = IsFunction();
                if (f != null) methods.Add(f);
                else
                {
                    //if (HasError) return null;
                    //FieldDeclarartionNode d = IsFieldDeclaration();
                    //if (d != null) fields.Add(d);
                    //else
                    //{
                    ///  if (HasError) return null;
                    //   if( !_tokenizer.Match( TokenType.ClosedCurly ) )
                    //    {
                            AddError( "Expected ending , function or field declaration." );
                    //}
                    //}
                }
                
            }
            return methods;
        }


        FunctionNode IsFunction()
        {
            if (!_tokenizer.MatchIdentifier("function")) return null;
   
            string name;
            string typeOfReturn;
            List<string> parametres = new List<string>();

            // Si ensuite on a les autres infos et une ouverture de parenthèse
            if (_tokenizer.IsIdentifier(out typeOfReturn)
                && _tokenizer.IsIdentifier(out name)
                && _tokenizer.Match(TokenType.OpenPar))
            {

                // On prend tout les params
                while (!_tokenizer.Match(TokenType.ClosedPar))
                {
                    string type_parametre;
                    if (_tokenizer.IsIdentifier(out type_parametre))
                    {
                        parametres.Add(type_parametre);
                    }
                    else
                    {
                        AddError("PB !");
                        return null;
                    }
                    _tokenizer.Match(TokenType.Comma);
                }
                if (_tokenizer.Match(TokenType.OpenCurly))
                {

                    FunctionNode fct = new FunctionNode(name, typeOfReturn, ParseFunctionBody(), parametres);
                    return fct;
                }
                else
                {
                    AddError("Arrive pas à commencer la fonction :'(");
                }
            }
            else
            {
                AddError("Fct creation plante...");
            }
            return null;
        }

        private List<InstructionNode> ParseFunctionBody()
        {
            List<InstructionNode> fct_content = new List<InstructionNode>();

            while(!_tokenizer.Match(TokenType.ClosedCurly) && !_tokenizer.IsEnd)
            {
                #region BeginOfSuperIfTribu
                if (_tokenizer.MatchIdentifier("stloc"))
                {
                    #region STLOC
                    string varName1;

                    if (_tokenizer.IsIdentifier(out varName1)
                        && _tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new StlocNode(varName1));
                    }
                    else
                    {
                        AddError("Local variable name expected.");
                        _tokenizer.ForwardToNextLine();

                    }
                    #endregion STLOC
                }
                else if (_tokenizer.MatchIdentifier("ldc"))
                {
                    #region LDC
                    int constante;
                    if (_tokenizer.IsInteger(out constante)
                        && _tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new LdcNode(constante));
                    }
                    else
                    {
                        AddError("Ldc need constante value");
                        _tokenizer.ForwardToNextLine();
                    }
                    #endregion
                }
                else if (_tokenizer.MatchIdentifier("ldstr"))
                {
                    #region LDSTR
                    string txt;
                    if (_tokenizer.IsString(out txt)
                        && _tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new LdstrNode(txt));
                    }
                    else
                    {
                        AddError("Ldc need constante value");
                        _tokenizer.ForwardToNextLine();
                    }
                    #endregion
                }
                else if (_tokenizer.MatchIdentifier("var"))
                {
                    #region VAR
                    // VAR
                    string label;
                    string vartype;

                    if (_tokenizer.IsIdentifier(out vartype)
                        && _tokenizer.IsIdentifier(out label)
                        && _tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new VarNode(vartype));
                    }
                    else
                    {
                        AddError("Can't create the variable");
                        _tokenizer.ForwardToNextLine();
                    }
                    #endregion
                }
                else if (_tokenizer.MatchIdentifier("nop"))
                {
                    #region NOP
                    if (_tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new NopNode());
                    }
                    else
                    {
                        AddError("Nop WHAT ?!");
                        _tokenizer.ForwardToNextLine();
                    }
                    #endregion
                }
                else if (_tokenizer.MatchIdentifier("ceq"))
                {
                    #region CEQ

                    if (_tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new CeqNode());
                    }
                    else
                    {
                        AddError("Error syntax with CEQ");
                        _tokenizer.ForwardToNextLine();
                    }
                    #endregion
                }
                else if (_tokenizer.MatchIdentifier("cgt"))
                {
                    #region CGT
                    if (_tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new CgtNode());
                    }
                    else
                    {
                        AddError("Error syntax with CGT");
                        _tokenizer.ForwardToNextLine();
                    }
                    #endregion
                }
                else if (_tokenizer.MatchIdentifier("clt"))
                {
                    #region CLT
                    if (_tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new CltNode());
                    }
                    else
                    {
                        AddError("Error syntax with CLT");
                        _tokenizer.ForwardToNextLine();
                    }
                    #endregion
                }
                else if (_tokenizer.MatchIdentifier("not"))
                {
                    #region NOT

                    if (_tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new NotNode());
                    }
                    else
                    {
                        AddError("Error syntax with NOT");
                        _tokenizer.ForwardToNextLine();
                    }
                    #endregion
                }
                else if (_tokenizer.MatchIdentifier("or"))
                {
                    #region OR
                    if (_tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new OrNode());
                    }
                    else
                    {
                        AddError("Error syntax with OR");
                        _tokenizer.ForwardToNextLine();
                    }
                    #endregion
                }
                else if (_tokenizer.MatchIdentifier("and"))
                {
                    #region AND

                    if (_tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new AndNode());
                    }
                    else
                    {
                        AddError("Error syntax with And");
                        _tokenizer.ForwardToNextLine();
                    }
                    #endregion
                }
                else if (_tokenizer.MatchIdentifier("brtrue"))
                {
                    #region BRTRUE
                    // VAR
                    string label;

                    if (_tokenizer.IsIdentifier(out label)
                        && _tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new BrtrueNode(label));
                    }
                    else
                    {
                        AddError("label of br expected");
                        _tokenizer.ForwardToNextLine();
                    }
                    #endregion
                }
                else if (_tokenizer.MatchIdentifier("brfalse"))
                {
                    #region BRFALSE
                    // VAR
                    string label;

                    if (_tokenizer.IsIdentifier(out label)
                        && _tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new BrfalseNode(label));
                    }
                    else
                    {
                        AddError("label of br expected");
                        _tokenizer.ForwardToNextLine();
                    }
                    #endregion
                }



                else if (_tokenizer.MatchIdentifier("br"))
                {
                    #region BR
                    // VAR
                    string label;

                    if (_tokenizer.IsIdentifier(out label)
                        && _tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new BrNode(label));
                    }
                    else
                    {
                        AddError("label of br expected");
                        _tokenizer.ForwardToNextLine();
                    }
                    #endregion
                }



                else if (_tokenizer.MatchIdentifier("add"))
                {
                    #region ADD
                    // VAR


                    if (_tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new AddNode());
                    }
                    else
                    {
                        AddError("How can you have an error with add ??");
                        _tokenizer.ForwardToNextLine();
                    }
                    #endregion
                }



                else if (_tokenizer.MatchIdentifier("mul"))
                {
                    #region MUL
                    // VAR


                    if (_tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new MulNode());
                    }
                    else
                    {
                        AddError("How can you have an error with mul ??");
                        _tokenizer.ForwardToNextLine();
                    }
                    #endregion
                }



                else if (_tokenizer.MatchIdentifier("div"))
                {
                    #region DIV
                    // VAR


                    if (_tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new DivNode());
                    }
                    else
                    {
                        AddError("How can you have an error with div ??");
                        _tokenizer.ForwardToNextLine();
                    }
                    #endregion
                }



                else if (_tokenizer.MatchIdentifier("sub"))
                {
                    #region SUB
                    // VAR


                    if (_tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new SubNode());
                    }
                    else
                    {
                        AddError("How can you have an error with sub ??");
                        _tokenizer.ForwardToNextLine();
                    }
                    #endregion
                }



                else if (_tokenizer.MatchIdentifier("neg"))
                {
                    #region NEG
                    // VAR


                    if (_tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new NegNode());
                    }
                    else
                    {
                        AddError("How can you have an error with neg ??");
                        _tokenizer.ForwardToNextLine();
                    }
                    #endregion
                }



                else if (_tokenizer.MatchIdentifier("write"))
                {
                    #region WRITE
                    // VAR
                    if (_tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new WriteNode());
                    }
                    else
                    {
                        AddError("How can you have an error with write ??");
                        _tokenizer.ForwardToNextLine();
                    }
                    #endregion
                }



                else if (_tokenizer.MatchIdentifier("read"))
                {
                    #region READ
                    // VAR


                    if (_tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new ReadNode());
                    }
                    else
                    {
                        AddError("How can you have an error with read ??");
                        _tokenizer.ForwardToNextLine();
                    }
                    #endregion
                }



                else if (_tokenizer.MatchIdentifier("ret"))
                {
                    #region RET
                    // VAR
                    string label;

                    if (_tokenizer.IsIdentifier(out label)
                        && _tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new RetNode(label));
                    }
                    else
                    {
                        AddError("How can you have an error with Ret ??");
                        _tokenizer.ForwardToNextLine();
                    }
                    #endregion
                }
                #endregion BeginOfSuperIfTribu
            }

            return fct_content;
        }

        private void AddError(string msg) {
            _errors.Add(new SyntaxError(msg));
        }
    }
}
