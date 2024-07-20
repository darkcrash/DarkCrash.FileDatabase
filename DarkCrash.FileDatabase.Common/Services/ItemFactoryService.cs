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
        /// <summary>
        /// singletone instance
        /// </summary>
        public static ItemFactoryService Instance = new ItemFactoryService();

        /// <summary>
        /// private constructor
        /// </summary>
        private ItemFactoryService() { }

        /// <summary>
        /// throw exception if file not found.
        /// </summary>
        /// <param name="path">target file path</param>
        /// <exception cref="FileNotFoundException">file not found</exception>
        private void ThrowNotFoundIfFileNotFound(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                throw new FileNotFoundException($"path:{path} のファイルが存在しません。");
            }
        }

        /// <summary>
        /// throw exception if directory not found.
        /// </summary>
        /// <param name="path">target directory path</param>
        /// <exception cref="FileNotFoundException">directory not found</exception>
        private void ThrowNotFoundIfDirectoryNotFound(string path)
        {
            if (!System.IO.Directory.Exists(path))
            {
                throw new DirectoryNotFoundException($"path:{path} のディレクトリが存在しません。");
            }
        }

        /// <summary>
        /// create file item from file path
        /// </summary>
        /// <param name="path">file path</param>
        /// <returns>file item</returns>
        /// <exception cref="FileNotFoundException">path not found</exception>
        public FileItem CreateFilItemWithoutHash(string path)
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
        /// create file item from directory path
        /// </summary>
        /// <param name="path">directory path</param>
        /// <returns>file items</returns>
        /// <exception cref="DirectoryNotFoundException">path not found</exception>
        public DirectoryItem CreateDirectoryItemsWithoutHash(string path)
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
                DataService.Instance.SaveItem(item);
                return item;
            }));

            return item;

        }

    }
}
