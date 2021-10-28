using System;
using System.IO;

namespace ChessManager.Logger
{
    /// <summary>
    /// LoggerChess
    /// </summary>
    public class LoggerChess
    {
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="ChessManager.Logger.LogBase" />
        public class Logger : LogBase
        {
            /// <summary>
            /// Gets the current directory.
            /// </summary>
            /// <value>
            /// The current directory.
            /// </value>
            private string CurrentDirectory { get; }

            /// <summary>
            /// Gets the name of the file.
            /// </summary>
            /// <value>
            /// The name of the file.
            /// </value>
            private string FileName { get; }

            /// <summary>
            /// Gets the file path.
            /// </summary>
            /// <value>
            /// The file path.
            /// </value>
            private string FilePath { get; }

            /// <summary>
            /// Initializes a new instance of the <see cref="Logger"/> class.
            /// </summary>
            /// <param name="name">The name.</param>
            public Logger(string name)
            {
                CurrentDirectory = Directory.GetCurrentDirectory();
                FileName = name;
                FilePath = CurrentDirectory + "/" + FileName;
            }

            /// <summary>
            /// Logs the specified messsage.
            /// </summary>
            /// <param name="messsage">The messsage.</param>
            public override void Log(string messsage)
            {
                using (StreamWriter w = File.AppendText(this.FilePath))
                {
                    w.Write("\nLog Entry : ");
                    w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                    w.WriteLine("  :{0}", messsage);
                }
            }
        }
    }
}