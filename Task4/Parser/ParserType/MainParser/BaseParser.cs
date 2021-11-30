using Gauss.MatrixMethod;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Parser.ParserType.MainParser
{
    /// <summary>
    /// BaseParser
    /// </summary>
    public abstract class BaseParser
    {
        /// <summary>
        /// Gets the matrix regex.
        /// </summary>
        /// <value>
        /// The matrix regex.
        /// </value>
        public abstract Regex MatrixRegex { get; }

        /// <summary>
        /// Determines whether [is correct element] [the specified element].
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>
        ///   <c>true</c> if [is correct element] [the specified element]; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsCorrectElement(string element) => MatrixRegex.IsMatch(element);

        /// <summary>
        /// Tries the parse.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="extendedMatrix">The extended matrix.</param>
        /// <returns></returns>
        public abstract IEnumerable TryParse(IEnumerable<string> matrix, out Matrix extendedMatrix);
    }
}