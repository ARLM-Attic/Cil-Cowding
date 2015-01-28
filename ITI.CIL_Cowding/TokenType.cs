using System;

namespace ITI.CIL_Cowding
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
