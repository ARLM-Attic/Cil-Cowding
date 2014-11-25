using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public class Analyser
    {
        ITokenizer _tokenizer;

        List<SyntaxError> _errors;

 

        public Analyser( ITokenizer tokenizer )
        {
            _tokenizer = tokenizer;
        }

 

        public List<InstructionNode> ParseBody()
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
