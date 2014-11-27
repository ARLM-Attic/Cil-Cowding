using System;

namespace ITI.CIL_Cowding
{
    public enum TokenType
    {
        None,
        Var,
        Nop,
        Ldc,
        Ldstr,
        Stloc,
        Ldloc,
        Ceq,
        Cgt,
        Clt,
        Not,
        Or,
        And,
        Brtrue,
        Brfalse,
        Br,
        Add,
        Mul,
        Div,
        Sub,
        Neg,
        Number,
        String,
        BeginString,
        EndOfString,
        Write,
        Read,
        Conv,
        Ret,
        Error,
        Text,
        Function,
        EndOfInput
    }
}
