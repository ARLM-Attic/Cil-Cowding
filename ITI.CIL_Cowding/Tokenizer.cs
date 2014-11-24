using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace ITI.CIL_Cowding
{

    public enum TokenType {
	    NONE,
	    VAR,
	    NOP,
	    LDC, 
        LDSTR,
	    STLOC,
        LDLOC,
	    CEQ, 
	    CGT,
        CLT,
	    NOT,
	    OR,
	    AND,
	    BRTRUE,
	    BRFALSE,
        BR,
	    ADD,
	    MUL,
	    DIV,
	    SUB,
	    NEG,
        NUMBER,
        STRING,
        BEGINSTRING,
        ENDOFSTRING,
	    WRITE,
	    READ,
        CONV,
        RET,
        ERROR,
        TEXT
    }

    public static class Tokeniser {

        /// <summary>
        /// Tokenize each instruction received.
        /// </summary>
        /// <param name="file">The instructions given by the interface (Val's part)</param>
        /// <returns>List which contains a list of tokens.</returns>
        public static List<Instruction> Tokenize( string file )
        {
            // Check if file contains white space
            if ( String.IsNullOrWhiteSpace(file) ) 
                throw new ArgumentNullException( "Argument must not be null or contain white spaces.", "file" );

            // List that we'll return
            List<Instruction> maliste = new List<Instruction>();

            // Take the string and split on new lines
            string[] lignes = file.Split( '\n');

            // Get every word of each line
            foreach(string ligne in lignes) {
                List<Token> ls_tk = new List<Token>();

                // Get every word which exist in the line
                string[] words = ligne.Split(' ', '\r');

                // Take each word separately
                foreach(string word in words) {
                        TokenType wordType = TokenType.NONE;
                        string data = "";

                        // Check if it seems like one of our keywords
                        #region SUPERSWITCHOTD
                        switch (word)
                        {
                            case "var":
                                wordType = TokenType.VAR; break;

                            case "nop":
                                wordType = TokenType.NOP; break;

                            case "ldc":
                                wordType = TokenType.LDC; break;

                            case "stloc":
                                wordType = TokenType.STLOC; break;

                            case "ldloc":
                                wordType = TokenType.LDLOC; break;

                            case "ldstr":
                                wordType = TokenType.LDSTR; break;

                            case "ceq":
                                wordType = TokenType.CEQ; break;

                            case "cgt":
                                wordType = TokenType.CGT; break;

                            case "clt":
                                wordType = TokenType.CLT; break;
                            case "not":
                                wordType = TokenType.NOT; break;

                            case "or":
                                wordType = TokenType.OR; break;

                            case "and":
                                wordType = TokenType.AND; break;

                            case "brtrue":
                                wordType = TokenType.BRTRUE; break;

                            case "brfalse":
                                wordType = TokenType.BRFALSE; break;

                            case "br":
                                wordType = TokenType.BR; break;

                            case "add":
                                wordType = TokenType.ADD; break;

                            case "mul":
                                wordType = TokenType.MUL; break;

                            case "div":
                                wordType = TokenType.DIV; break;

                            case "sub":
                                wordType = TokenType.SUB; break;

                            case "neg":
                                wordType = TokenType.NEG; break;

                            case "WRITE":
                                wordType = TokenType.WRITE; break;

                            case "READ":
                                wordType = TokenType.READ; break;

                            case "ret":
                                wordType = TokenType.RET; break;

                            case "conv":
                                wordType = TokenType.CONV; break;

                            case "int" :
                                wordType = TokenType.NUMBER;
                                break;
                            case "string" :
                                wordType = TokenType.STRING;
                                break;

                            // Else we see if it's a number or not...
                            default:
                                int nb;
                                if (int.TryParse(word, out nb))
                                {
                                    wordType = TokenType.NUMBER;
                                    data = Convert.ToString(nb);
                                }
                                // If it's neither of the Keywords above nor a number, 
                                // see if it's a beginning of a string.
                                else if (Regex.IsMatch(word, @"^"""))   // if word begins by a double quote
                                {
                                    if (Regex.IsMatch(word, @"""$"))   // if it also finishes by a double quote (without any split)
                                    {
                                        wordType = TokenType.STRING;   // then it's a token type string
                                        data = word;                   // value of string
                                    }
                                    else
                                    {
                                        wordType = TokenType.BEGINSTRING; // else it's a token type of a string beginning
                                        data = word;
                                    }
                                }
                                else if (!word.Contains("\""))             // if the word doesn't contains any double quote
                                {
                                    wordType = TokenType.TEXT;             // then we give a TT which is a text
                                    data = word;
                                }
                                else if (Regex.IsMatch(word, @"""$"))      // if word ends by a double quote
                                {
                                    wordType = TokenType.ENDOFSTRING;       // then it's a token type ending of the string
                                    data = word;
                                }
                                else
                                {
                                    wordType = TokenType.ERROR;             // fuck off, error
                                }

                                // LABELS, TODO
                                break;
                        }
                        #endregion SUPERSWITCHOTD

                        // Create the token that we'll add to the list 
                        Token tk = new Token(wordType, data);
                        ls_tk.Add(tk);
                        
                    
                }

                // We finished our instruction, we have all tokens for current instruction, so create an instruction
                Instruction ins = new Instruction(ls_tk);
                
                maliste.Add(ins);
                
                
            }

            // Return our instructions list
            return maliste;
    
         }
    }
}