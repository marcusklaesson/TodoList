using System;
using System.IO;
using TodoList.Android;
using TodoList.Persistence;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace TodoList.Android
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}