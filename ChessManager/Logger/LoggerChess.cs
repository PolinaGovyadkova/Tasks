using System;
using System.IO;

namespace ChessManager.Logger
{
    public class LoggerChess
    {
        public class Logger : LogBase
        {
            private string CurrentDirectory { get; }

            private string FileName { get; }

            private string FilePath { get; }

            public Logger(string name)
            {
                CurrentDirectory = Directory.GetCurrentDirectory();
                FileName = name;
                FilePath = CurrentDirectory + "/" + FileName;
            }

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