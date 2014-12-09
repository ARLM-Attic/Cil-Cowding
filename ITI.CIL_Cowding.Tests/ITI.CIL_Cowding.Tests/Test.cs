using NUnit.Framework;
using System;

namespace ITI.CIL_Cowding.Tests
{
    [TestFixture]
    public class Test
    {
            StringTokenizer st = new StringTokenizer("ldstr \"hello\";\n");
        
            TokenType tk = st.CurrentToken;
        
            Assert.That( tk, Is.EqualTo( TokenType.Identifier ) );
    }
}
