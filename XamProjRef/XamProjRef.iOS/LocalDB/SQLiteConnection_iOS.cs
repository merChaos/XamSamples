using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using XamProjRef1.LocalDB;
using SQLite.Net;
using System.IO;
using Xamarin.Forms;
using XamProjRef.iOS.LocalDB;

[assembly: Dependency(typeof(SQLiteConnection_iOS))]
namespace XamProjRef.iOS.LocalDB
{
    class SQLiteConnection_iOS : ISQLiteConnection
    {

        public SQLiteConnection_iOS()
        {

        }
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "MyLocalDb.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); 
            var path = Path.Combine(documentsPath, sqliteFilename);

            var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);

            // Return the database connection 
            return conn;
        }
    }
}