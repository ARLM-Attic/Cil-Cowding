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
            Assert.That(tk, Is.EqualTo(TokenType.Identifier));
        }

        [Test]
        public void is_a_string_token()
        {
            StringTokenizer st = new StringTokenizer("\"\"coucou\"a string\" 1454 toto");
            string s;
            // we must have ""
            Assert.That(st.IsString(out s));
            Assert.That(s, Is.EqualTo(""));
            // we must have coucou
            Assert.That(st.MatchIdentifier("coucou"));
            // we must have "" 
            Assert.That(st.IsString(out s) && s == "a string");

            Assert.That(st.IsString(out s), Is.False);
            Assert.That(st.IsIdentifier(out s), Is.False);
            Assert.That(st.Match(TokenType.OpenCurly), Is.False);
            Assert.That(st.MatchIdentifier("b"), Is.False);
            int i;
            Assert.That(st.IsInteger(out i) && i == 1454);

            Assert.That(st.IsString(out s), Is.False);
            Assert.That(st.IsInteger(out i), Is.False);
            Assert.That(st.Match(TokenType.SemiColon), Is.False);
            Assert.That(st.MatchIdentifier("YOYO"), Is.False);

            Assert.That(st.MatchIdentifier("toto"));
            Assert.That(st.Match(TokenType.EndOfInput));

        }

        [Test]
        public void test_if_we_have_the_right_value_of_string()
        {
            string s = "\"text\"";

            StringTokenizer st = new StringTokenizer(s);
            TokenType tk = st.CurrentToken;

            bool value = st.IsString(out s);
            string valueOfTxt = st.GetValueOfId;

            Assert.That(value, Is.True);
            Assert.That(valueOfTxt, Is.EqualTo("text"));

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

        [Test]
        public void is_an_identifier()
        {
            TokenType tk;
            StringTokenizer strtk = new StringTokenizer("coucou");
            tk = strtk.CurrentToken;
            Assert.That(tk == TokenType.Identifier);
        }

        [Test]
        public void is_a_string()
        {
            TokenType tk;
            StringTokenizer strtk = new StringTokenizer("\"coucou\"");
            tk = strtk.CurrentToken;
            Assert.That(tk == TokenType.String);
            string valueOfString = strtk.GetValueOfId;
            Assert.That(valueOfString == "coucou");
        }

        [Test]
        public void full_program()
        {
            TokenType tkt;
            string s = @"function void main () {
	            locals_init(
		            int fac
	            )
                write;
	
	            ldstr ""fin :-)"";
	            write;
	
            }
            // line 1
            // line 2
            // line 3
            function int fact(int nb) {
	            locals_init(
		            int retour_fct
	            )
            /*
	            ldarg 0;
	            ldc 1;
	            ceq;*/
	            brfalse recur;
	            ldc /*1;
	            ret;
	
	
	            #recur
	            ldarg 0;
	            ldc 1;
	            sub;
	            call fact;
	            ldarg 0;
	            mul;
	            ret;
            */	
            }

            ";
            StringTokenizer st = new StringTokenizer(s);
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.Identifier));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.Identifier));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.Identifier));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.OpenPar));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.ClosedPar));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.OpenCurly));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.Identifier));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.OpenPar));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.Identifier));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.Identifier));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.ClosedPar));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.Identifier));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.SemiColon));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.Identifier));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.String));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.SemiColon));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.Identifier));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.SemiColon));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.ClosedCurly)); // End of tokens' main function.
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.Identifier));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.Identifier));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.Identifier));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.OpenPar));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.Identifier));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.Identifier));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.ClosedPar));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.OpenCurly));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.Identifier));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.OpenPar));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.Identifier));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.Identifier));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.ClosedPar));
            st.GetNextToken();
            tkt = st.CurrentToken;
            Assert.That(tkt, Is.EqualTo(TokenType.Identifier));
        }
    }
}