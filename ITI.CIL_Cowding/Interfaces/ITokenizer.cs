using System;

namespace ITI.CIL_Cowding
{
    public interface ITokenizer
    {
        /// <summary>
        /// Gets the current token.
        /// </summary>
        TokenType CurrentToken { get; }

        /// <summary>
        /// Gets the zero-based line number of the current token.
        /// </summary>
        int CurrentLine { get; }

        /// <summary>
        /// Gets the zero-based column number of the current token.
        /// </summary>
        int CurrentColumn { get; }

        /// <summary>
        /// Tests if the current character is a white space.
        /// </summary>
        /// <returns>True if if is, False if it's not.</returns>
         bool IsWhiteSpace { get; }

        /// <summary>
        /// Tests if we are at the end of the string.
        /// </summary>
        /// <returns>True if we are, or false if we're not at the end.</returns>
        bool IsEnd { get; } 

        /// <summary>
        /// Reads the character and ups the playhead then ("tête de lecture" in french).
        /// </summary>
        /// <returns>The string with the playhead not updated (post inc.)</returns>
        char Read();

        /// <summary>
        /// Reads the current character under the playhead
        /// </summary>
        /// <returns>The string with the current position.</returns>
        char Peek();

        /// <summary>
        /// Tests if the value is an integer.
        /// </summary>
        /// <param name="value">value that we test</param>
        /// <returns>Returns true if it's an integer.</returns>
        bool IsInteger(out int value);

        bool IsVarType(out VarType value);

        /// <summary>
        /// Tests if the value is a double.
        /// </summary>
        /// <param name="value">value that we test</param>
        /// <returns>Returns true if it's a double.</returns>
        
        bool IsDouble(out double value);

        /// <summary>
        /// Tests if the value is a string.
        /// </summary>
        /// <param name="value">value that we test</param>
        /// <returns>Returns true if it's a string</returns>
        bool IsString(out string value);

        bool IsIdentifier(out string id);

        /// <summary>
        /// Gets the next Token.
        /// </summary>
        /// <returns>The token of TokenType type.</returns>
        TokenType GetNextToken();

        
        // REDOU
        bool MatchIdentifier(string identifier);

        /// <summary>
        /// Ups to the next character
        /// </summary>
        void Forward();

        /// <summary>
        /// Goes to the next line of the next instruction
        /// </summary>
        void ForwardToNextLine();

        bool Match(TokenType t);

         bool Match(int expectedValue);

         void ForwardToNextLine();
    }
}