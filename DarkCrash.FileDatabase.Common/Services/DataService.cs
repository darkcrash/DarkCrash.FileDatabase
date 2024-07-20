using DarkCrash.FileDatabase.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace DarkCrash.FileDatabase.Common.Services
{
    /// <summary>
    /// データサービス
    /// </summary>
    public class DataService
    {

        private string DirectoryPath = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), AppDomain.CurrentDomain.FriendlyName);

        private Dictionary<long, List<FileItem>> Data = new Dictionary<long, List<FileItem>>();

        public static DataService Instance { get; private set; } = new DataService();
        private DataService() { }

        public void SaveItem(FileItem item)
        {
            var path = System.IO.Path.Combine(DirectoryPath, item.Path);
            if (!Data.ContainsKey(item.Size))
            {
                Data.Add(item.Size, new List<FileItem>());
            }
            var result = Data[item.Size].Where(_ => _.FullName == item.FullName).FirstOrDefault();
            if (result != null)
            {
                result.Sha1 = item.Sha1;
                result.MD5 = item.MD5;
            }
            else
            {
                Data[item.Size].Add(item);
            }
        }

        public void LoadItem(FileItem item)
        {
            var path = System.IO.Path.Combine(DirectoryPath, item.Path);
            if (Data.ContainsKey(item.Size))
            {
                var result = Data[item.Size].Where(_ => _.FullName == item.FullName).FirstOrDefault();
                if (result != null)
                {
                    item.Sha1 = result.Sha1;
                    item.MD5 = result.MD5;
                }
            }
        }

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
        }

        public async Task LoadAsync()
        {
            var path = System.IO.Path.Combine(DirectoryPath, "datastore");
            var file = new FileInfo(path);
            if (!file.Exists) return;
            using FileStream stream = file.Open(FileMode.Open);
            Data = await JsonSerializer.DeserializeAsync<Dictionary<long, List<FileItem>>>(stream) ?? Data;
        }


    }
}
