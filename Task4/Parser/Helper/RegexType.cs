using System.Text.RegularExpressions;

namespace Parser
{
    public static class RegexType
    {
        public static readonly Regex AlphabetRegex = new Regex("[a-zA-Z]");
        public static readonly Regex NumberRegex = new Regex(@"-?(\d)+");
    }
}