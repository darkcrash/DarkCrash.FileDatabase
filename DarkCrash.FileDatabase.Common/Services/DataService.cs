﻿using DarkCrash.FileDatabase.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Runtime.CompilerServices;

namespace DarkCrash.FileDatabase.Common.Services
{
    /// <summary>
    /// データサービス
    /// </summary>
    public class DataService
    {
        /// <summary>
        /// base directory path of data store
        /// </summary>
        private string DirectoryPath = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), AppDomain.CurrentDomain.FriendlyName);

        /// <summary>
        /// in-memory data store
        /// </summary>
        private Dictionary<long, List<FileItem>> Data = new Dictionary<long, List<FileItem>>();

        /// <summary>
        /// singletone instance
        /// </summary>
        public static DataService Instance { get; private set; } = new DataService();

        /// <summary>
        /// private constructor
        /// </summary>
        private DataService() { }

        /// <summary>
        /// save item to in-memory
        /// </summary>
        /// <param name="item">saving item</param>
        public void SaveItem(FileItem item)
        {
            lock (Data)
            {
                if (!Data.ContainsKey(item.Size))
                {
                    Data.Add(item.Size, new List<FileItem>());
                }
            }
            var result = Data[item.Size].Where(_ => _.FullName == item.FullName).FirstOrDefault();
            if (result != null)
            {
                result.Sha1 = item.Sha1;
            }
            else
            {
                Data[item.Size].Add(item);
            }
        }

        /// <summary>
        /// load iten from in-memory
        /// </summary>
        /// <param name="item">loading item</param>
        public void LoadItem(FileItem item)
        {
            if (Data.ContainsKey(item.Size))
            {
                lock (Data[item.Size])
                {
                    var result = Data[item.Size].Where(_ => _.FullName == item.FullName).FirstOrDefault();
                    if (result != null)
                    {
                        item.Sha1 = result.Sha1;
                    }
                }

            }
        }

        /// <summary>
        /// remove item from in-memory
        /// </summary>
        /// <param name="item">removing item</param>
        public void RemoveItem(FileItem item)
        {
            if (Data.ContainsKey(item.Size))
            {
                lock (Data[item.Size])
                {
                    var result = Data[item.Size].Where(_ => _.FullName == item.FullName).FirstOrDefault();
                    if (result != null)
                    {
                        Data[item.Size].Remove(result);
                    }
                }
            }
        }

        /// <summary>
        /// save items collection to file
        /// </summary>
        /// <returns>Task</returns>
        public async Task SaveAsync()
        {
            var path = System.IO.Path.Combine(DirectoryPath, "datastore");
            System.IO.Directory.CreateDirectory(DirectoryPath);
            var file = new FileInfo(path);
            using FileStream stream = file.Open(FileMode.OpenOrCreate);
            var option = new JsonSerializerOptions()
            {
                WriteIndented = false,
                IgnoreReadOnlyProperties = true
            };
            await JsonSerializer.SerializeAsync(stream, Data, option);
            await stream.FlushAsync();
        }

        /// <summary>
        /// load items collection from file
        /// </summary>
        /// <returns>Task</returns>
        public async Task LoadAsync()
        {
            var path = System.IO.Path.Combine(DirectoryPath, "datastore");
            var file = new FileInfo(path);
            if (!file.Exists) return;
            using FileStream stream = file.Open(FileMode.Open);
            try
            {
                Data = await JsonSerializer.DeserializeAsync<Dictionary<long, List<FileItem>>>(stream) ?? Data;
            }
            catch (Exception) { }
        }

        /// <summary>
        /// get same size items with target item 
        /// </summary>
        /// <param name="item">target item</param>
        /// <returns>duplicate items</returns>
        public IEnumerable<FileItem> GetSameSizeFiles(FileItem item)
        {
            if (!Data.ContainsKey(item.Size)) yield break;
            foreach (var i in Data[item.Size].ToArray())
            {
                if (!System.IO.File.Exists(i.FullName))
                {

                    continue;
                }
                yield return i;
            }
        }

        /// <summary>
        /// get duplicate items with target item
        /// </summary>
        /// <param name="item">target item</param>
        /// <returns>duplicate items</returns>
        public IEnumerable<FileItem> GetDuplicateFiles(FileItem item)
        {
            if (!Data.ContainsKey(item.Size)) yield break;
            foreach (var f in Data[item.Size])
            {
                if (f.Sha1 == item.Sha1) yield return f;
            }
        }

    }
}
