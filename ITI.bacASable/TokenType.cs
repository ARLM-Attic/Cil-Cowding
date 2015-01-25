using System;

namespace ITI.bacASable
{
    public enum TokenType
    {
        None,
        Var,
        Minus,
        OpenPar,            // (
        ClosedPar,          // )
        OpenBracket,        // [
        ClosedBracket,      // ]
        OpenCurly,          // {
        ClosedCurly,        // }
        Dot,                // .
        Colon,              // :
        DoubleColon,        // ::
        SemiColon,          // ;
        Comma,              // ,
        Number,
        String,
        Error,
        Identifier,
        EndOfLine,
        ErrorUnterminatedString,
        EndOfInput,
        ErrorInvalidUnicodeInString,
        HashTag,        // #
    }
}
