using System;

namespace ITI.CIL_Cowding
{
    public enum TokenType
    {
        None,
        Var,
        Minus,
        OpenPar, 
        ClosedPar,
        Dot,
        Colon, 
        DoubleColon,
        SemiColon,
        Number,
        String,
        Error,
        Identifier,
        EndOfLine,
        ErrorUnterminatedString,
        EndOfInput,
        ErrorInvalidUnicodeInString,
        Comma,
        OpenCurly,
        ClosedCurly
    }
}
