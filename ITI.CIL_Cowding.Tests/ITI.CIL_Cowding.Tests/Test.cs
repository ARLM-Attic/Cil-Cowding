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
        public void is_an_identifier_token()
        {
            StringTokenizer st = new StringTokenizer("ldstr");
            TokenType tk = st.CurrentToken;
            Assert.That( tk, Is.EqualTo( TokenType.Identifier ) );
        }

        [Test]
        public void is_a_string_token()
        {
            StringTokenizer st = new StringTokenizer("\"\"coucou\"\"");
            string strToCp;
            // ""
            Assert.That(st.IsString(out strToCp));
            Assert.That(strToCp, Is.EqualTo(""));
            // coucou
            Assert.That(st.MatchIdentifier("coucou"));
            // "" 
            Assert.That(st.IsString(out strToCp) && strToCp == "");
        }

        [Test]
        public void is_the_right_string()
        {
            StringTokenizer st = new StringTokenizer(@" ""cou""cou"" ");
            string str;
            Assert.That(st.IsString(out str));
            Assert.That(str, Is.EqualTo(@"cou""cou"));

        }

        [Test]
        public void test_if_we_have_the_right_value_of_string()
        {
            string s = "\"text\"";

            StringTokenizer st = new StringTokenizer( s );
            TokenType tk = st.CurrentToken;

            bool value = st.IsString( out s );
            string valueOfTxt = st.GetValueOfId;

            Assert.That( value, Is.True );
            Assert.That(valueOfTxt, Is.EqualTo( "text" ) );

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