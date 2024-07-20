using DarkCrash.FileDatabase.Common.Models;
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
            await stream.FlushAsync();
        }

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
            catch (Exception ex) { }
        }

        public IEnumerable<FileItem> GetDuplicateSizeFiles(FileItem item)
        {
            if (!Data.ContainsKey(item.Size)) yield break;
            foreach (var i in Data[item.Size].ToArray())
            {
                yield return i;
            }
        }



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
