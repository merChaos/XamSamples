using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamProjRef1.LocalDB;
using SQLite.Net;
using System.IO;
using Xamarin.Forms;
using XamProjRef.Droid.LocalDB;

[assembly: Dependency(typeof(SQLiteConnection_Android))]
namespace XamProjRef.Droid.LocalDB
{
    class SQLiteConnection_Android : ISQLiteConnection
    {
        public SQLiteConnection_Android()
        {
           
        }
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "MyLocalDb.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);

            var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);

            // Return the database connection 
            return conn;
        }
    }
}