using System.Text.RegularExpressions;

namespace Parser.Helper
{
    /// <summary>
    /// RegexType
    /// </summary>
    public static class RegexType
    {
        /// <summary>
        /// The alphabet regex
        /// </summary>
        public static readonly Regex AlphabetRegex = new Regex("[a-zA-Z]");

        /// <summary>
        /// The number regex
        /// </summary>
        public static readonly Regex NumberRegex = new Regex(@"-?(\d)+");
    }
}