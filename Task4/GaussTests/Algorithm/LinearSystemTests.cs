using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gauss.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gauss.MatrixMethod;

namespace Gauss.Algorithm.Tests
{
    [TestClass()]
    public class LinearSystemTests
    {
        [TestMethod()]
        public void GaussLinearSystemSolveTest()
        {
            var matrix = new double[3, 4]
            {
                {2, 1, -1, 8},
                {-3, -1, 2, -11},
                {-2, 1, 7, -3}
            };
            var matrix1 = new Matrix(matrix);
            var algorithm = new LinearSystem(matrix1);
            var result = algorithm.GaussSolve();
            const string resultString = "Vector X:\n3,25\n1,75\n0,25\n";
            Assert.AreEqual(resultString, result);
        }

        [TestMethod()]
        public void GaussSolveTest()
        {
            var matrix = new double[3, 4]
            {
                {2, 1, -1, 8},
                {-3, -1, 2, -11},
                {-2, 1, 7, -3}
            };
            var matrix1 = new Matrix(matrix);
            var algorithm = new DistributedLinearSystem(matrix1);
            var result = algorithm.GaussSolve();
            const string resultString = "Vector X:\n3,25\n1,75\n0,25\n";
            Assert.AreEqual(resultString, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(GaussException))]
        public void GaussSolveExceptionTest()
        {
            var matrix = new double[3, 3]
            {
                {2, 1, -1},
                {-3, -1, 2},
                {-2, 1, 7}
            };
            var matrix1 = new Matrix(matrix);
            var algorithm = new DistributedLinearSystem(matrix1);
            var result = algorithm.GaussSolve();
            const string resultString = "Vector X:\n3,25\n1,75\n0,25\n";
            Assert.AreEqual(resultString, result);
        }

        [TestMethod]
        public void TestResultComparison()
        {
            var matrix = new double[3, 4]
            {
                {2, 1, -1, 8},
                {-3, -1, 2, -11},
                {-2, 1, 7, -3}
            };
            var matrix1 = new Matrix(matrix);
            var algorithmDistributed = new DistributedLinearSystem(matrix1);
            var resultDistributed = algorithmDistributed.GaussSolve();
            var algorithm = new LinearSystem(matrix1);
            var result = algorithm.GaussSolve();
            for (int i = 0; i < matrix1.LastColumn().Length; i++)
            {
                Assert.IsTrue(Math.Abs(algorithm.VectorX[i] - algorithmDistributed.VectorX[i]) < 0.001);
            }
        }
    }
}