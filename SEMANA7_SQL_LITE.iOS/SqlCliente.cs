using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using SQLite;
using System.IO;
[assembly: Xamarin.Forms.Dependency(typeof(Sqlcliente))]

namespace SEMANA7_SQL_LITE.iOS
{
    class SqlCliente:DataBase
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documenrtPath = System.Environment
                    .GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documenrtPath, "uisrael.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}
}