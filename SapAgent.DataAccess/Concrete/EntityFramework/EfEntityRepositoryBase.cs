using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Abstract;

namespace SapAgent.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                var list = filter != null ?
                    context.Set<TEntity>().Where(filter).ToList() :
                    context.Set<TEntity>().ToList();

                return list;
            }
        }

        public TEntity Add(TEntity entry)
        {
            try
            {
                using (TContext context = new TContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var ent = context.Entry(entry);
                        ent.State = EntityState.Added;
                        context.SaveChanges();
                        transaction.Commit(); // Does not throw.
                    }
                }
                return entry;
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    throw e.InnerException;
                throw;
            }

        }

        public void Update(TEntity entry)
        {
            try
            {
                using (TContext context = new TContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {

                        var ent = context.Entry(entry);
                        ent.State = EntityState.Modified;
                        context.SaveChanges();
                        transaction.Commit();
                    }
                }
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    throw e.InnerException;
                throw;
            }

        }

        public void ExecuteStoreProc(string sql)
        {
            var query = sql;
            using (TContext context = new TContext())
            {
                context.Database.ExecuteSqlCommand(query);
            }
        }

        public void Upsert(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var entry = context.Entry(entity);
                switch (entry.State)
                {
                    case EntityState.Detached:
                        Add(entity);
                        break;
                    case EntityState.Modified:
                        Update(entity);
                        break;
                    case EntityState.Added:
                        Add(entity);
                        break;
                    case EntityState.Unchanged:
                        //item already in db no need to do anything  
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void Delete(TEntity entry)
        {
            using (TContext context = new TContext())
            {
                var ent = context.Entry(entry);
                ent.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
