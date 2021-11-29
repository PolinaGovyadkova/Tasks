using Gauss.MatrixMethod;
using Parser.Helper;
using System.Collections.Generic;
using System.Linq;

namespace Parser
{
    public class MatrixParser
    {
        private static readonly IEnumerable<BaseParser> Parsers = new List<BaseParser>() { new NumberParser(), new AlphabetSymbol(), };

        public static IEnumerable<T> TryParse<T>(IEnumerable<string> matrix, out Matrix extendedMatrix)
        {
            var representation = matrix.ToList();
            var symbolWithNumber = representation.First().Split(' ');
            foreach (var parser in Parsers)
            {
                if (!parser.IsCorrectElement(symbolWithNumber.First())) continue;
                var variableNames = parser.TryParse(representation, out Matrix result) as IEnumerable<T>;
                extendedMatrix = result;
                return variableNames;
            }

            throw new MatrixException(typeof(T).Name);
        }
    }
}