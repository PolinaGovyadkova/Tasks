using Gauss.MatrixMethod;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Parser
{
    public class AlphabetSymbol : BaseParser
    {

        public override Regex MatrixRegex => new Regex(@"[a-zA-Z]$");
        public override IEnumerable TryParse(IEnumerable<string> matrix, out Matrix extendedMatrix)
        {
            var representation = matrix.ToList();
            var variableNames = RegexType.AlphabetRegex.Matches(representation.First()).OfType<Match>().Select(element => element.Value.First());
            var matrixBase = (from row in representation
                              let correctSymbols = RegexType.AlphabetRegex.Matches(row).Cast<Match>().Select(element => element.Value.First())
                              select row.Split(' ')
                into symbolWithNumber
                              let resultRow = Convert.ToDouble(symbolWithNumber.Last())
                              select symbolWithNumber.OrderBy(element => element.Last())
                                  .SkipLast(1)
                                  .Select(element => RegexType.NumberRegex.Matches(element).Cast<Match>().Select(y => Convert.ToDouble(y.Value)))
                                  .SelectMany(item => item)
                                  .ToList()
                                  .Append(resultRow)).ToList();
            extendedMatrix = new Matrix(matrixBase);
            return variableNames;
        }
    }
}