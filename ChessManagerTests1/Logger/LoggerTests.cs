using ChessManager.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessManagerTests1.Logger
{
    /// <summary>
    /// LoggerTests
    /// </summary>
    [TestClass()]
    public class LoggerTests
    {
        /// <summary>
        /// The logger
        /// </summary>
        private LoggerChess.Logger _logger = new LoggerChess.Logger("LogTest.txt");
        /// <summary>
        /// Logs the test.
        /// </summary>
        [TestMethod()]
        public void LogTest()
        {
            bool flag = false;
            for (int i = 0; i < 40; i++)
            {
                _logger.Log("TestMessage" + i);
            }

            if (System.IO.File.Exists("LogTest.txt")) flag = true;
                Assert.IsTrue(flag);
        }
    }
}