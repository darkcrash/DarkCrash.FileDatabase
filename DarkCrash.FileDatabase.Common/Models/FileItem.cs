using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        [JsonPropertyName("n")]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// file directory path
        /// </summary>
        [JsonPropertyName("p")]
        public string Path { get; set; } = string.Empty;
        /// <summary>
        /// file full path
        /// </summary>
        [JsonIgnore]
        public string FullName { get => System.IO.Path.Combine(Path, Name); }
        /// <summary>
        /// file size
        /// </summary>
        [JsonPropertyName("s")]
        public long Size { get; set; } = default(int);
        /// <summary>
        /// SHA1 hash
        /// </summary>
        [JsonPropertyName("h")]
        public byte[] Sha256 { get; set; } = [];
        /// <summary>
        /// sha1 hash text
        /// </summary>
        [JsonIgnore]
        public string Sha256Text { get => string.Join("", Sha256.Select(_ => _.ToString("X2"))); }
        /// <summary>
        /// same size item count
        /// </summary>
        [JsonIgnore]
        public int SameSizeCount { get; set; } = 0;
    }
}
