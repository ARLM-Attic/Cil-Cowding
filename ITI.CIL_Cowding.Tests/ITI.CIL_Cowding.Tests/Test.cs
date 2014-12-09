using NUnit.Framework;
using System;

namespace ITI.CIL_Cowding.Tests
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void if_we_have_the_right_tokens()
        {
            // ARRANGE
            StringTokenizer st = new StringTokenizer("ldstr \"hello\";\n");

            // ACT
            TokenType tk = st.CurrentToken;

            // ASSERT
            Assert.That( tk, Is.EqualTo( TokenType.Identifier ) );
        }
    }
}
