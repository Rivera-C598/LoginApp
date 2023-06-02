using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LoginApp;
using LoginApp.Droid;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: Dependency(typeof(FileHelper))]
namespace LoginApp.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename) 
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, filename);
        }
    }
}