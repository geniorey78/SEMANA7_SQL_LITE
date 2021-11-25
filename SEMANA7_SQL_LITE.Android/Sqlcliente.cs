using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.IO;
using SEMANA7_SQL_LITE.Droid;

[assembly:Xamarin.Forms.Dependency(typeof(Sqlcliente))]
namespace SEMANA7_SQL_LITE.Droid
{
    class Sqlcliente:DataBase
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documenrtPath = System.Environment
                    .GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documenrtPath,"uisrael.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}