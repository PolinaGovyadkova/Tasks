using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Parser
{
    public class FileGetter
    {
        private readonly FileInfo _fileInfo;

        public FileGetter(string directory, string file)
        {
            _fileInfo = new DirectoryInfo(directory).GetFiles().First(delegate (FileInfo f)
            {
                if (f.Name.Contains(file)) return true;
                return false;
            });
        }

        public IEnumerable<string> GetContent() => File.ReadAllLines(_fileInfo.FullName);
    }
}