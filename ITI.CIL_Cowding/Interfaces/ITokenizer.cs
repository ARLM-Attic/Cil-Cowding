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
        /// Ups to the next character
        /// </summary>
        void Forward();

        /// <summary>
        /// Tests if we are at the end of the string.
        /// </summary>
        /// <returns>True if we are, or false if we're not at the end.</returns>
        bool IsEnd();

        /// <summary>
        /// Tests if the current character is a white space.
        /// </summary>
        /// <returns>True if if is, False if it's not.</returns>
        bool IsWhiteSpace();

        /// <summary>
        /// Gets the next Token.
        /// </summary>
        /// <returns>The token of TokenType type.</returns>
        TokenType GetNextToken();
    }
}
