using DarkCrash.FileDatabase.Common.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        /// computing hash feature
        /// </summary>
        public static HMACSHA1 SHA1 = new HMACSHA1();

        /// <summary>
        /// compute hash
        /// </summary>
        /// <param name="path">file path</param>
        /// <returns>file item</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static async Task<FileItem> ComputeHashAsync(this FileItem item )
        {
            var info = new FileInfo(item.FullName);

            // update file size
            item.Size = info.Length;

            // computing hash value
            using (var stream = info.OpenRead())
            {
                item.Sha1 = await SHA1.ComputeHashAsync(stream);
            }

            // save item information
            DataService.Instance.SaveItem(item);

            return item;
        }

        /// <summary>
        /// compute hash
        /// </summary>
        /// <param name="path">file path</param>
        /// <returns>process</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static Process? OpenShell(this FileItem item)
        {
            // shell based execution
            var info = new System.Diagnostics.ProcessStartInfo(item.FullName);
            info.UseShellExecute = true;
            return System.Diagnostics.Process.Start(info);
        }



    }
}
