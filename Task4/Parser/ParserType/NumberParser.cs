using Gauss.MatrixMethod;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Parser
{
    public class NumberParser : BaseParser
    {
        public override Regex MatrixRegex => new Regex(@"^-?(\d)+$");
        public override IEnumerable TryParse(IEnumerable<string> matrix, out Matrix extendedMatrix)
        {
            var matrixElements = matrix.Select(s => s.Split(' ').Select(Convert.ToDouble));
            var fullMatrix = matrixElements.ToList();
            extendedMatrix = new Matrix(fullMatrix);
            return Enumerable.Range(0, fullMatrix.Count());
        }
    }
}