using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Parser.Helper
{
    /// <summary>
    /// FileGetter
    /// </summary>
    public class FileGetter
    {
        /// <summary>
        /// The file information
        /// </summary>
        private readonly FileInfo _fileInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileGetter"/> class.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <param name="file">The file.</param>
        public FileGetter(string directory, string file)
        {
            _fileInfo = new DirectoryInfo(directory).GetFiles().First(delegate (FileInfo f)
            {
                if (f.Name.Contains(file)) return true;
                return false;
            });
        }

        /// <summary>
        /// Gets the content.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetContent() => File.ReadAllLines(_fileInfo.FullName);
    }
}