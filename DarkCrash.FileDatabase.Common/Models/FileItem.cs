using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkCrash.FileDatabase.Common.Models
{
    /// <summary>
    /// ファイル項目
    /// </summary>
    public class FileItem
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
        /// ファイルパス
        /// </summary>
        public string FullName { get => System.IO.Path.Combine(Path, Name); }
        /// <summary>
        /// サイズ
        /// </summary>
        public long Size { get; set; } = default(int);
        /// <summary>
        /// SHA1ハッシュ
        /// </summary>
        public byte[] Sha1 { get; set; } = [];
        public string Sha1Text { get => string.Join("", Sha1.Select(_ => _.ToString("X2"))); }
        /// <summary>
        /// MD5ハッシュ
        /// </summary>
        public byte[] MD5 { get; set; } = [];
    }
}
