using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using SQLite;
using UIKit;
using Xamarin.Forms;
using XF.CRMaster.DAO;
using XF.CRMaster.iOS.Implementations;

[assembly: Dependency(typeof(SQliteIOS))]
namespace XF.CRMaster.iOS.Implementations
{
    class SQliteIOS : IDatabaseConnection
    {
        //private readonly string dbase = "crmaster.db3";
        private SQLiteConnection connection;
        private SQLiteAsyncConnection connectionAsync;

        public SQLiteConnection GetConnection()
        {
            var path = GetDBPath();
            connection = new SQLiteConnection(path);
            return connection;
        }

        public SQLiteAsyncConnection GetConnectionAsync()
        {
            var path = GetDBPath();
            connectionAsync = new SQLiteAsyncConnection(path);
            return connectionAsync;
        }

        public void Dispose()
        {
            connection.Dispose();
        }

        public string GetDBPath()
        {
            var dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(dbpath, "..", "Library");
        }
    }
}