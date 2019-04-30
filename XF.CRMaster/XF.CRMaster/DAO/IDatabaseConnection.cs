using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XF.CRMaster.DAO
{
    public interface IDatabaseConnection : IDisposable
    {

        SQLiteConnection GetConnection();

        SQLiteAsyncConnection GetConnectionAsync();
        string GetDBPath();

    }
}
