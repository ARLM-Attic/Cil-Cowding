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
        List<IError> _errors;
        IEngine _engine;

        public Analyzer(ITokenizer tokenizer, IEngine engine)
        {
            _tokenizer = tokenizer;
            _errors = new List<IError>();
            _engine = engine;
        }

        public List<FunctionNode> ParseBody()
        {

            List<FunctionNode> methods = new List<FunctionNode>();
            //List<FieldDeclarartionNode> methods = new List<FieldDeclarartionNode>();

            while (!_tokenizer.IsEnd)
            {

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
            if ( _errors.Count >= 1)
            {
                _engine.ClashError( _errors );
            }
            
            return methods;
        }

        FunctionNode IsFunction()
        {
            if (!_tokenizer.MatchIdentifier("function")) return null;
   
            string name;
            string returnType;
            List<string> parameters = new List<string>();

            // Si ensuite on a les autres infos et une ouverture de parenthèse
            if (_tokenizer.IsIdentifier(out returnType)
                && _tokenizer.IsIdentifier(out name)
                && _tokenizer.Match(TokenType.OpenPar))
            {

                // On prend tout les params
                while (!_tokenizer.Match(TokenType.ClosedPar))
                {
                    string parameterType;
                    string osef;
                    if (_tokenizer.IsIdentifier(out parameterType) && _tokenizer.IsIdentifier(out osef))
                    {
                        parameters.Add(parameterType);
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

                    FunctionNode fct = new FunctionNode(name, returnType, ParseFunctionBody(), parameters);
                    return fct;
                }
                else
                {
                    AddError("Cannot begin function... :("); 
                }
            }
            else
            {
                AddError("Error on Function creation..."); 
            }
            return null;
        }

        private List<InstructionNode> ParseFunctionBody()
        {
            List<InstructionNode> fct_content = new List<InstructionNode>();

            while(!_tokenizer.Match(TokenType.ClosedCurly) && !_tokenizer.IsEnd)
            {
                #region BeginOfSuperIfTribu
                // Gestion des localinit
                if (_tokenizer.MatchIdentifier("locals_init"))
                {
                    #region LOCALS_INIT
                    List<string> loc_var = new List<string>();
                    string type;
                    string tmp;

                    if (_tokenizer.Match(TokenType.OpenPar))
                    {
                        
                        while(!_tokenizer.Match(TokenType.ClosedPar) && !_tokenizer.IsEnd)
                        {
                            if (_tokenizer.IsIdentifier(out type)
                                && _tokenizer.IsIdentifier(out tmp))
                            {

                                loc_var.Add(type);

                            }
                            else
                            {
                                AddError("Bug au niveau de la déclaration d'un variable");
                            }
                            _tokenizer.Match(TokenType.Comma);

                        }
                        if (_tokenizer.IsEnd)
                        {
                            AddError("Ben ... C'est déjà la fin ???");
                        }

                        fct_content.Add(new LocalsInitNode(loc_var));

                    }
                    else
                    {
                        AddError("Locals Init BUUUG");
                        _tokenizer.ForwardToNextLine();

                    }
                    #endregion LOCALS_INIT
                }

                else if (_tokenizer.MatchIdentifier("stloc"))
                {
                    #region STLOC
                    int index;

                    if (_tokenizer.IsInteger(out index)
                        && _tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new StlocNode(index));
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
                    #endregion LDC
                }

                else if( _tokenizer.MatchIdentifier( "ldloc" ) )
                {
                    #region LDLOC
                    int index;
                    if( _tokenizer.IsInteger( out index ) 
                        && _tokenizer.Match( TokenType.SemiColon ) )
                    {
                        fct_content.Add(new LdlocNode( index ) );
                    }
                    else
                    {
                        AddError( "Something failed with ldloc. This node needs an index." );
                        _tokenizer.ForwardToNextLine();
                    }
                    #endregion LDLOC
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
                        AddError("Ldstr need text as a value.");
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

                else if( _tokenizer.MatchIdentifier( "call" ) )
                {
                    #region CALL
                    string labelNameFct;
                    if( _tokenizer.IsIdentifier( out labelNameFct ) &&
                        _tokenizer.Match( TokenType.SemiColon ) )
                    {
                        fct_content.Add(new CallNode( labelNameFct ) );
                    }
                    else
                    {
                        AddError( "Error : somthing has failed with call." );
                        _tokenizer.ForwardToNextLine();
                    }
                    #endregion CALL
                }
                else if (_tokenizer.MatchIdentifier("ret"))
                {
                    #region RET
                    // VAR
                    string label;

                    if (_tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new RetNode());
                    }
                    else
                    {
                        AddError("How can you have an error with Ret ??");
                        _tokenizer.ForwardToNextLine();
                    }
                    #endregion
                }

                else if (_tokenizer.MatchIdentifier("ldloc"))
                {
                    #region ldloc

                    // VAR
                    int index;

                    if (_tokenizer.IsInteger(out index)
                        && _tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new LdlocNode(index));
                    }
                    else
                    {
                        AddError("How can you have an error with LDLOC ??");
                        _tokenizer.ForwardToNextLine();
                    }

                    #endregion ldloc
                }
                else if (_tokenizer.MatchIdentifier("ldarg"))
                {
                    #region ldarg

                    // VAR
                    int index;

                    if (_tokenizer.IsInteger(out index)
                        && _tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new LdargNode(index));
                    }
                    else
                    {
                        AddError("How can you have an error with LDARG ??");
                        _tokenizer.ForwardToNextLine();
                    }

                    #endregion ldarg
                }
                else if (_tokenizer.MatchIdentifier("starg"))
                {
                    #region starg

                    // VAR
                    int index;

                    if (_tokenizer.IsInteger(out index)
                        && _tokenizer.Match(TokenType.SemiColon))
                    {
                        fct_content.Add(new StargNode(index));
                    }
                    else
                    {
                        AddError("How can you have an error with starg ??");
                        _tokenizer.ForwardToNextLine();
                    }

                    #endregion starg
                }
                else if (_tokenizer.Match(TokenType.HashTag))
                {
                    #region Label
                    string label;

                    if ( _tokenizer.IsIdentifier( out label ) )
                    {
                        fct_content.Add( new LabelNode( label ) );
                    }
                    else
                    {
                        AddError( "Error on label declaration" );
                        _tokenizer.ForwardToNextLine();
                    }
                    #endregion
                }

                else
                {
                    AddError("Identifiant non reconnu.");
                }
                #endregion BeginOfSuperIfTribu
            }

            return fct_content;
        }

        private void AddError(string msg)
        {
            _errors.Add( new SyntaxError( _engine, msg ) );
            _tokenizer.ForwardToNextLine();
            
        }

    }

}