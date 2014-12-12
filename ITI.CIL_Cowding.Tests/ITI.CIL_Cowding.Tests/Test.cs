using NUnit.Framework;
using System;

namespace ITI.CIL_Cowding.Tests
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void is_a_number_token()
        {
            StringTokenizer st = new StringTokenizer("40");
            TokenType tk = st.CurrentToken;
            Assert.That(tk, Is.EqualTo(TokenType.Number));
        }

        [Test]
        public void is_a_identifier_token()
        {
            StringTokenizer st = new StringTokenizer("ldstr");
            TokenType tk = st.CurrentToken;
            Assert.That( tk, Is.EqualTo( TokenType.Identifier ) );
        }

        [Test]
        public void is_a_string_token()
        {
            StringTokenizer st = new StringTokenizer("\"coucou\"");
            TokenType tk = st.CurrentToken;
            Assert.That( tk, Is.EqualTo( TokenType.String ) );
        }

        [Test]
        public void skip_comments()
        {
            StringTokenizer st = new StringTokenizer("// comment\nldc 4;");
            TokenType tk = st.CurrentToken;
            Assert.That(tk, Is.EqualTo(TokenType.Identifier));
        }

        [Test]
        public void skip_comments_block()
        {
            StringTokenizer st = new StringTokenizer("/* comment */ ldc 4;");
            TokenType tk = st.CurrentToken;
            Assert.That(tk, Is.EqualTo(TokenType.Identifier));
        }

        [Test]
        public void get_error_of_unterminated_string()
        {
            StringTokenizer st = new StringTokenizer("\"cou");
            TokenType tk = st.CurrentToken;
            Assert.That(tk, Is.EqualTo(TokenType.ErrorUnterminatedString));
        }
    }
}
