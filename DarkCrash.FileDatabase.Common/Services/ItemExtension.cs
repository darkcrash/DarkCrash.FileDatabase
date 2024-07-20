using DarkCrash.FileDatabase.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DarkCrash.FileDatabase.Common.Services
{
    /// <summary>
    /// 項目生成サービス
    /// </summary>
    public static class ItemExtension
    {
        public static HMACSHA1 SHA1 = new HMACSHA1();
        public static HMACMD5 MD5 = new HMACMD5();

        /// <summary>
        /// ファイル項目のハッシュを計算する
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <returns>ファイル項目</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static async Task<FileItem> ComputeHashAsync(this FileItem item )
        {
            var info = new FileInfo(item.FullName);

            item.Size = info.Length;
            using (var stream = info.OpenRead())
            {
                item.Sha1 = await SHA1.ComputeHashAsync(stream);
                stream.Seek(0, SeekOrigin.Begin);
                item.MD5 = await MD5.ComputeHashAsync(stream);
            }

            return item;

        }



    }
}
