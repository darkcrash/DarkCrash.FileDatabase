using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkCrash.FileDatabase.Common.Models
{
    /// <summary>
    /// file item model
    /// </summary>
    public class FileItem
    {
        /// <summary>
        /// file name
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// file directory path
        /// </summary>
        public string Path { get; set; } = string.Empty;
        /// <summary>
        /// file full path
        /// </summary>
        public string FullName { get => System.IO.Path.Combine(Path, Name); }
        /// <summary>
        /// file size
        /// </summary>
        public long Size { get; set; } = default(int);
        /// <summary>
        /// SHA1 hash
        /// </summary>
        public byte[] Sha1 { get; set; } = [];
        public string Sha1Text { get => string.Join("", Sha1.Select(_ => _.ToString("X2"))); }
    }
}
