using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkCrash.FileDatabase.Common.Models
{
    /// <summary>
    /// ディレクトリ項目
    /// </summary>
    public class DirectoryItem
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// パス
        /// </summary>
        public string Path { get; set; } = string.Empty;
        /// <summary>
        /// ファイル
        /// </summary>
        public List<FileItem> Files { get; } = new List<FileItem>();

    }
}
