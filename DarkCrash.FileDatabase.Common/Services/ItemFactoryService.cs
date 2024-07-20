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
    public class ItemFactoryService
    {
        public HMACSHA1 SHA1 = new HMACSHA1();
        public HMACMD5 MD5 = new HMACMD5();

        public static ItemFactoryService Instance = new ItemFactoryService();
        private ItemFactoryService() { }


        private void ThrowNotFoundIfFileNotFound(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                throw new FileNotFoundException($"path:{path} のファイルが存在しません。");
            }
        }

        private void ThrowNotFoundIfDirectoryNotFound(string path)
        {
            if (!System.IO.Directory.Exists(path))
            {
                throw new FileNotFoundException($"path:{path} のディレクトリが存在しません。");
            }
        }

        /// <summary>
        /// ファイル項目を生成する
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <returns>ファイル項目</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public async Task<FileItem> CreateFileFullItem(string path)
        {
            ThrowNotFoundIfFileNotFound(path);

            var info = new FileInfo(path);
            var item = new FileItem();

            item.Name = info.Name;
            item.Path = info.DirectoryName ?? string.Empty;
            item.Size = info.Length;
            using (var stream = info.OpenRead())
            {
                item.Sha1 = await SHA1.ComputeHashAsync(stream);
            }

            return item;

        }

        /// <summary>
        /// ファイル項目を生成する
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <returns>ファイル項目</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public async Task<FileItem> CreateFilItemWithoutHash(string path)
        {
            ThrowNotFoundIfFileNotFound(path);

            var info = new FileInfo(path);
            var item = new FileItem();

            item.Name = info.Name;
            item.Path = info.DirectoryName ?? string.Empty;
            item.Size = info.Length;

            return item;

        }



        /// <summary>
        /// ファイル項目を生成する
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <returns>ファイル項目</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public async Task<DirectoryItem> CreateDirectoryItemsWithoutHash(string path)
        {
            ThrowNotFoundIfDirectoryNotFound(path);

            var info = new DirectoryInfo(path);
            var item = new DirectoryItem();

            item.Name = info.Name;
            item.Path = info.FullName;

            item.Files.AddRange(info.GetFiles().Select(_ =>
            {
                var item = new FileItem();
                item.Name = _.Name;
                item.Path = _.DirectoryName ?? string.Empty;
                item.Size = _.Length;
                DataService.Instance.LoadItem(item);
                return item;
            }));

            return item;

        }

    }
}
