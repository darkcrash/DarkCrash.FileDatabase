using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkCrash.FileDatabase.Common.Models
{
    /// <summary>
    /// directory item model
    /// </summary>
    public class DirectoryItem
    {
        /// <summary>
        /// directory name
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// directory path
        /// </summary>
        public string Path { get; set; } = string.Empty;
        /// <summary>
        /// file items in directory
        /// </summary>
        public List<FileItem> Files { get; } = new List<FileItem>();

    }
}
