using Gauss.MatrixMethod;
using Parser.ParserType.MainParser;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Parser.ParserType
{
    /// <summary>
    /// NumberParser
    /// </summary>
    /// <seealso cref="Parser.ParserType.MainParser.BaseParser" />
    public class NumberParser : BaseParser
    {
        /// <summary>
        /// Gets the matrix regex.
        /// </summary>
        /// <value>
        /// The matrix regex.
        /// </value>
        public override Regex MatrixRegex => new Regex(@"^-?(\d)+$");

        /// <summary>
        /// Tries the parse.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="extendedMatrix">The extended matrix.</param>
        /// <returns></returns>
        public override IEnumerable TryParse(IEnumerable<string> matrix, out Matrix extendedMatrix)
        {
            var matrixElements = matrix.Select(s => s.Split(' ').Select(Convert.ToDouble));
            var fullMatrix = matrixElements.ToList();
            extendedMatrix = new Matrix(fullMatrix);
            return Enumerable.Range(0, fullMatrix.Count());
        }
    }
}