using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XF.CRMaster.DAO;

namespace XF.CRMaster.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected SQLiteConnection _connection { get; set; }

        public Repository()
        {
            _connection = new CustumersDataAccess().GetConnection();
        }

        public IList<TEntity> GetAll()
        {
            return _connection.Table<TEntity>().ToList();
        }

        public TEntity Get(int id)
        {
            return _connection.Find<TEntity>(id);
        }

        public IList<TEntity> GetAll<TValue>(Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, TValue>> orderBy = null)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _connection.Find<TEntity>(predicate);
        }

        public TableQuery<TEntity> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public int Insert(TEntity entity)
        {
            return _connection.Insert(entity);
        }

        public int Update(TEntity entity)
        {
           return _connection.Update(entity);
        }

        public int Delete(TEntity entity)
        {
            return _connection.Delete(entity);
        }
    }

}

