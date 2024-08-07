﻿using DarkCrash.FileDatabase.Common.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DarkCrash.FileDatabase.Common.Services
{
    /// <summary>
    /// file item extension
    /// </summary>
    public static class FileItemExtension
    {

        /// <summary>
        /// compute hash
        /// </summary>
        /// <param name="item">file item</param>
        /// <returns>file item</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static async Task<FileItem> ComputeHashAsync(this FileItem item)
        {
            var info = new FileInfo(item.FullName);

            if (!info.Exists) { return item; }

            // update file size
            item.Size = info.Length;

            // computing hash value
            using HashAlgorithm Hash = SHA256.Create();
            using (var stream = info.OpenRead())
            {
                Hash.Initialize();
                item.Sha256 = await Hash.ComputeHashAsync(stream);
            }

            // save item information
            DataService.Instance.SaveItem(item);

            return item;
        }

        /// <summary>
        /// compute hash
        /// </summary>
        /// <param name="item">file item</param>
        /// <returns>process</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static Process? OpenShell(this FileItem item)
        {
            // shell based execution
            var info = new System.Diagnostics.ProcessStartInfo(item.FullName);
            info.UseShellExecute = true;
            try
            {
                return System.Diagnostics.Process.Start(info);
            }
            catch (Exception) { return null; }
        }

        /// <summary>
        /// compute hash
        /// </summary>
        /// <param name="item">file item</param>
        /// <returns>process</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static bool Trash(this FileItem item)
        {
            // shell based execution
            var param = new NavtiveShell.SHFILEOPSTRUCTA();
            param.wFunc = NavtiveShell.FileFuncFlags.FO_DELETE;
            param.fFlags = NavtiveShell.FILEOP_FLAGS.FOF_ALLOWUNDO;
            param.pFrom = item.FullName + "\0";

            var result = NavtiveShell.SHFileOperation(ref param) == 0;
            if (result)
            {
                DataService.Instance.RemoveItem(item);
            }
            return result;

        }

    }
}
