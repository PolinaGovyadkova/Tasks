using Gauss.Algorithm;
using Gauss.MatrixMethod;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser.Helper;
using Parser.ParserType.MainParser;
using System.IO;

namespace Parser.Tests
{
    /// <summary>
    /// LettersPatternParserTests
    /// </summary>
    [TestClass()]
    public class LettersPatternParserTests
    {
        /// <summary>
        /// Tries the parse exception test.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void TryParseExceptionTest()
        {
            var dirPath = $@"../ERROR";
            const string fileName = "matrix.txt";
            var matrixGetter = new FileGetter(dirPath, fileName);
            var matrix = matrixGetter.GetContent();
            MatrixParser.TryParse<string>(matrix, out Matrix extendedMatrix);
            var algorithm = new DistributedLinearSystem(extendedMatrix);
            var result = algorithm.GaussSolve();
            const string resultString = "Vector X:\n-0,125\n-0,75\n1,875\n";
            Assert.AreEqual(resultString, result);
        }

        /// <summary>
        /// Tries the parse test.
        /// </summary>
        [TestMethod()]
        public void TryParseTest()
        {
            var dirPath = $@"../Debug";
            const string fileName = "matrix.txt";
            var matrixGetter = new FileGetter(dirPath, fileName);
            var matrix = matrixGetter.GetContent();
            MatrixParser.TryParse<string>(matrix, out Matrix extendedMatrix);
            var algorithm = new DistributedLinearSystem(extendedMatrix);
            var result = algorithm.GaussSolve();
            const string resultString = "Vector X:\n-0,125\n-0,75\n1,875\n";
            Assert.AreEqual(resultString, result);
        }

        /// <summary>
        /// Tries the parse with symbols test.
        /// </summary>
        [TestMethod()]
        public void TryParseWithSymbolsTest()
        {
            var dirPath = $@"../Debug";
            const string fileName = "matrixWithSymbols.txt";
            var matrixGetter = new FileGetter(dirPath, fileName);
            var matrix = matrixGetter.GetContent();
            MatrixParser.TryParse<string>(matrix, out Matrix extendedMatrix);
            var algorithm = new DistributedLinearSystem(extendedMatrix);
            var result = algorithm.GaussSolve();
            const string resultString = "Vector X:\n-7,68968\n2,14947\n8,95336\n-8,08134\n3,0437\n";
            Assert.AreEqual(resultString, result);
        }
    }
}