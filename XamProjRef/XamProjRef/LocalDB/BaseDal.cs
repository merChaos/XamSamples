using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamProjRef1.Model;

namespace XamProjRef1.LocalDB
{
    public abstract class BaseDal
    {
        static object locker = new object ();

		static SQLiteConnection _database = DependencyService.Get<ISQLiteConnection>().GetConnection ();

		public static SQLiteConnection Database {
			get {
				lock (locker) {
					return _database;
				}
			}
		}

		/// <summary>
		/// Static Constructor
		/// </summary>
        static BaseDal()
		{
			// Create the tables

			Database.CreateTable<User> ();
		}
    }
}
