using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace XF.CRMaster.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {

        IList<TEntity> GetAll();
        TEntity Get(int id);
        IList<TEntity> GetAll<TValue>(Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, TValue>> orderBy = null);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        TableQuery<TEntity> AsQueryable();
        int Insert(TEntity entity);
        int Update(TEntity entity);
        int Delete(TEntity entity);

    }
}
