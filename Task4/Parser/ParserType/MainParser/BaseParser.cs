using Gauss.MatrixMethod;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Parser
{
    public abstract class BaseParser
    {
        public abstract Regex MatrixRegex { get; }

        public virtual bool IsCorrectElement(string element) => MatrixRegex.IsMatch(element);

        public abstract IEnumerable TryParse(IEnumerable<string> matrix, out Matrix extendedMatrix);
    }
}