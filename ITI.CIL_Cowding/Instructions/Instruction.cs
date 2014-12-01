using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public class Instruction
    {

        List<Token> _instruction;
      /*  TokenType _instruction[0].Type;
        string _instruction[1].Data;
        string _instruction[2].Data;
        */
        public Instruction( List<Token> instruction )
        {
            _instruction = instruction;
            /*
            _instruction[0].Type = _instruction[0].Type;
            _instruction[1].Data = _instruction[1].Data;
            _instruction[2].Data = _instruction[2].Data;*/
        }
        
        /// <summary>
        /// Analyse and Execute a Token from tokenizer
        /// </summary> 
        public int Execute()
        {
            #region switch trolol c'est pas régionné automatiquent #fuckvisualstudio
            switch ( _instruction[0].Type )
            {
                // SWITCH OF THE WALKING DEAD
                case TokenType.None:
                    break;
                case TokenType.Var:
                    Var();
                    break;
                case TokenType.Nop:
                    // Do nothing
                    break;
                case TokenType.Ldc:
                    Ldc();
                    break;
                case TokenType.Ldstr:
                    Ldstr();
                    break;
                case TokenType.Stloc:
                    Stloc();
                    break;
                case TokenType.Ldloc:
                    ldloc();
                    break;
                case TokenType.Ceq:
                    Ceq();
                    break;
                case TokenType.Cgt:
                    Cgt();
                    break;

                case TokenType.Clt:
                    Clt();
                    break;

                case TokenType.Not:
                    Not();
                    break;
                case TokenType.Or:
                    Or();
                    break;
                case TokenType.And:
                    And();
                    break;
                case TokenType.Brtrue:
                    return Brtrue();
                //break;
                case TokenType.Brfalse:
                    return Brfalse();
                case TokenType.Br:
                    return Br();
                //break;
                case TokenType.Add:
                    Add();
                    break;
                case TokenType.Mul:
                    Mul();
                    break;
                case TokenType.Div:
                    Div();
                    break;
                case TokenType.Sub:
                    Sub();
                    break;
                case TokenType.Neg:
                    Neg();
                    break;
                case TokenType.Write:
                    Write();
                    break;
                case TokenType.Read:
                    Read();
                    break;
                default:
                    Console.Out.WriteLine("F@cking error on _instruction.CurrentToken.Value Switchiz");
                    break;
            }
            #endregion
            return -1;
        }

        #region _instructions

        #region Logic Operator

        /// <summary>
        /// Bitwise AND of two integral values, returns an integral value.
        /// </summary>
        private void And()
        {
            Variable temp1 = CIL_Stack.PopVar();
            Variable temp2 = CIL_Stack.PopVar();
            if ( temp1.Type == VarType.Var_Bool && temp2.Type == VarType.Var_Bool )
            {
                bool temp = ( Convert.ToBoolean( temp2.Data ) && Convert.ToBoolean( temp1.Data ) );
                if ( temp == true )
                    CIL_Stack.PushVar( new Variable( VarType.Var_Bool, "1" ) );
                else
                    CIL_Stack.PushVar( new Variable( VarType.Var_Bool, "0" ) );
            }
            else
                Console.WriteLine( "Error on logical And operator. Are you retarded ?" );
        }
        /// <summary>
        /// Bitwise OR of two integer values, returns an integer.
        /// </summary>
        private void Or()
        {
            Variable temp1 = CIL_Stack.PopVar();
            Variable temp2 = CIL_Stack.PopVar();
            if ( temp1.Type == VarType.Var_Bool && temp2.Type == VarType.Var_Bool )
            {
                bool temp = ( Convert.ToBoolean( temp2.Data ) || Convert.ToBoolean( temp1.Data ) );
                if ( temp == true )
                    CIL_Stack.PushVar( new Variable( VarType.Var_Bool, "1" ) );
                else
                    CIL_Stack.PushVar( new Variable( VarType.Var_Bool, "0" ) );
            }
            else
                Console.WriteLine( "Error on logical Or operator. Are you trying to compare non bool ?" );
        }
        /// <summary>
        /// Bitwise complement (logical not).
        /// </summary>
        private void Not()
        {
            Variable temp1 = CIL_Stack.PopVar();
            if ( temp1.Type == VarType.Var_Bool )
            {
                bool temp = ! Convert.ToBoolean( temp1.Data );
                if ( temp == true )
                    CIL_Stack.PushVar( new Variable( VarType.Var_Bool, "1" ) );
                else
                    CIL_Stack.PushVar( new Variable( VarType.Var_Bool, "0" ) );
            }
            else
                Console.WriteLine( "Error on logical Not operator. Are you trying to compare non bool ?" );
        }


        #endregion

        #region Operators

        /// <summary>
        /// Add two values, push a new value.
        /// </summary>
        private void Add()
        {
            Variable temp1 = CIL_Stack.PopVar();
            Variable temp2 = CIL_Stack.PopVar();
            if ( temp1.Type == VarType.Var_Int && temp2.Type == VarType.Var_Int )
                CIL_Stack.PushVar( new Variable( VarType.Var_Int, Convert.ToString( ( Convert.ToInt32( temp2.Data ) + Convert.ToInt32( temp1.Data ) ) ) ) );
            else
                Console.WriteLine( "Error on add operator. Are you trying to add non int ?" );
        }
        /// <summary>
        /// Subtract temp1 from temp2, push a new value.
        /// </summary>
        private void Sub()
        {
            Variable temp1 = CIL_Stack.PopVar();
            Variable temp2 = CIL_Stack.PopVar();
            if ( temp1.Type == VarType.Var_Int && temp2.Type == VarType.Var_Int )
                CIL_Stack.PushVar( new Variable( VarType.Var_Int, Convert.ToString( ( Convert.ToInt32(temp2.Data) - Convert.ToInt32(temp1.Data) ) ) ) );
            else
                Console.WriteLine( "Error on sub operator. Are you trying to sub non int ?" );
        }
        /// <summary>
        /// Multiply two values, push a new value.
        /// </summary>
        private void Mul()
        {
            Variable temp1 = CIL_Stack.PopVar();
            Variable temp2 = CIL_Stack.PopVar();
            if ( temp1.Type == VarType.Var_Int && temp2.Type == VarType.Var_Int )
                CIL_Stack.PushVar( new Variable( VarType.Var_Int, Convert.ToString( Convert.ToInt32(temp2.Data) * Convert.ToInt32(temp1.Data) ) ) );
            else
                Console.WriteLine( "Error on mult operator. Are you trying to add non int ?" );
        }
        /// <summary>
        /// Divide two values to push a quotient or floating-point result.
        /// </summary>
        private void Div()
        {
            Variable temp1 = CIL_Stack.PopVar();
            Variable temp2 = CIL_Stack.PopVar();
            if ( temp1.Type == VarType.Var_Int && temp2.Type == VarType.Var_Int )
                CIL_Stack.PushVar( new Variable( VarType.Var_Int, Convert.ToString( ( Convert.ToInt32(temp2.Data) / Convert.ToInt32(temp1.Data) ) ) ) );
            else
                Console.WriteLine( "Error on div operator. Are you trying to div non int ?" );
        }
         /// <summary>
         /// Negate an integer
         /// </summary>
        private void Neg()
        {
            Variable temp = CIL_Stack.PopVar();
            if ( temp.Type == VarType.Var_Int )
                CIL_Stack.PushVar( new Variable( VarType.Var_Int, Convert.ToString( ( -1 * Convert.ToInt32( temp.Data ) ) ) ) );
            else
                Console.WriteLine( "Error, int exepted" );
        }

        #endregion

        #region Comparators

        /// <summary>
        /// Push 1 (of type int32) if value1 equals value2, else push 0.
        /// </summary>
        private void Ceq()
        {
            Variable temp1 = CIL_Stack.PopVar();
            Variable temp2 = CIL_Stack.PopVar();
            if ( temp1.Type == temp2.Type )
            {
                if ( temp1.Data == temp2.Data )
                    CIL_Stack.PushVar( new Variable( VarType.Var_Int, "1" ) );
                else
                    CIL_Stack.PushVar( new Variable( VarType.Var_Int, "0" ) );
            }
            else
            {
                Console.WriteLine( "Error on comparator. Are you trying to compare differents types ?" );
            }
        }

        /// <summary>
        /// Push 1 (of type int32) if value1 > value2, else push 0.
        /// </summary>
        private void Cgt()
        {
            Variable temp1 = CIL_Stack.PopVar();
            Variable temp2 = CIL_Stack.PopVar();
            if ( temp1.Type == temp2.Type )
            {
                if ( Convert.ToInt32(temp1.Data) > Convert.ToInt32(temp2.Data) )
                    CIL_Stack.PushVar( new Variable( VarType.Var_Int, "1" ) ); 
                else
                    CIL_Stack.PushVar( new Variable( VarType.Var_Int, "0" ) ); 
            }
            else
            {
                Console.WriteLine( "Error on comparator. Are you trying to compare differents types ?" );
            }
        }

        /// <summary>
        /// Push 1 (of type int32) if value2 > value1, else push 0.
        /// </summary>
        private void Clt()
        {
            Variable temp1 = CIL_Stack.PopVar();
            Variable temp2 = CIL_Stack.PopVar();
            if ( temp1.Type == temp2.Type )
            {
                if ( Convert.ToInt32( temp1.Data ) < Convert.ToInt32( temp2.Data ) )
                    CIL_Stack.PushVar( new Variable( VarType.Var_Int, "1" ) );
                else
                    CIL_Stack.PushVar( new Variable( VarType.Var_Int, "0" ) );
            }
            else
            {
                Console.WriteLine( "Error on comparator. Are you trying to compare differents types ?" );
            }
        }

        #endregion

        #region loop

        /// <summary>
        /// Branch to target if value is non-zero (true).
        /// </summary>
        private int Brtrue()
        {
            Variable temp = CIL_Stack.PopVar();
            if ( temp.Data == "1" )
            {
                return Convert.ToInt32( _instruction[1].Data );
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Branch to target if value is zero (false).
        /// </summary>
        private int Brfalse()
        {
            Variable temp = CIL_Stack.PopVar();
            if ( temp.Data == "0" )
            {
                return Convert.ToInt32(_instruction[1].Data);
            }
            else
            {
                return -1; ;
            }
        }
        private int Br()
        {
            return Convert.ToInt32(_instruction[1].Data);
        }
        #endregion

        #region Local Variables
       
        /// <summary>
        /// Pop a value from the stack to a local variable
        /// </summary>
        private void Stloc()
        {
            Variable temp = CIL_Stack.PopVar();
            temp.Label = _instruction[1].Data;
            CIL_Stack.SetLocalVar( temp );
        }

        /// <summary>
        /// Push local variable
        /// </summary>
        private void ldloc()
        {
            CIL_Stack.PushVar( CIL_Stack.GetLocalVar( _instruction[1].Data ) );
        }
        /// <summary>
        /// Create new local variable
        /// </summary>
        private void Var()
        {
            VarType VarType_temp;
            switch( _instruction[1].Type )
            {
                case TokenType.Number :
                    VarType_temp = VarType.Var_Int;
                    break;
                case TokenType.Text :
                    VarType_temp  = VarType.Var_String;
                    break;
                default :
                    VarType_temp = VarType.Var_None;
                    break;
            }
            CIL_Stack.SetLocalVar( new Variable( VarType_temp, "", _instruction[2].Data) );
        }
        #endregion

        #region Load

        /// <summary>
        /// Push an integer on the stack
        /// </summary>
        private void Ldc()
        {
            if (_instruction[1].Type == TokenType.Number)
            {
                CIL_Stack.PushVar( new Variable( VarType.Var_Int, _instruction[1].Data ) );
            }
            else
            {
                Console.WriteLine( "Error, integer exepted" );
            }
        }

        /// <summary>
        /// Push a string on the stack
        /// </summary>
        private void Ldstr()
        {
            // On concatène toute la string suivante
            string tmp = "";
            for (int i = 1; i<_instruction.Count; i++ )
            {
                tmp += _instruction[i].Data + " ";
            }

            CIL_Stack.PushVar( new Variable(VarType.Var_String , tmp));
           

            /*
            if (_instruction[1].Type == TokenType.STRING)
            {

                CIL_Stack.PushVar( new Variable( VarType.Var_String, _instruction[1].Data ) );
            }
            else
            {
                Console.WriteLine( "Error, string exepted" );
            }
             * */
        }

        #endregion

        #region Personnal functions
        /// <summary>
        /// Write text to console output
        /// </summary>
        private void Write()
        {
            Console.WriteLine( CIL_Stack.PopVar().Data );
        }
        /// <summary>
        /// Read text from console input
        /// </summary>
        private void Read()
        {
            Console.Write("Input ==> ");
            Variable tmp = new Variable( VarType.Var_String, Console.ReadLine() );
            CIL_Stack.PushVar(tmp);
        }

        #endregion

        #endregion

        private void Conv()
        {

            
            Variable tmp = CIL_Stack.PopVar();
            if (_instruction[1].Type == TokenType.Number)
            {
                tmp.Type = VarType.Var_Int;

            } else {
                tmp.Type = VarType.Var_String;
            }

            CIL_Stack.PushVar(tmp);

        }
    
    
    }
}