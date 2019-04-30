using System.IO;
using SQLite;
using Xamarin.Forms;
using XF.CRMaster.DAO;
using XF.CRMaster.Droid.Implementations;

[assembly: Dependency(typeof(SQliteAndroid))]
namespace XF.CRMaster.Droid.Implementations
{
    class SQliteAndroid : IDatabaseConnection
    {
        private readonly string dbase = "crmaster.db";
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

        public string GetDBPath()
        {
            var dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(dbpath, dbase);
        }

        public void Dispose()
        {
            connection.Dispose();
        }




    }
}