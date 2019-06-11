using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Weather.Domain.Interfaces;

namespace Weather.DAL.Base
{
    public class GenericRepository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        #region Atributos

        public WeatherContext context;
        internal DbSet<TEntity> DbSet;

        #endregion

        #region Construtor

        public GenericRepository(WeatherContext context)
        {
            this.context = context;
            DbSet = context.Set<TEntity>();
        }

        #endregion

        #region Métodos

        public virtual IQueryable<TEntity> GetBy(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                try
                {
                    query = query.Where(filter);
                }
                catch (DbEntityValidationException ee)
                {
                    var erros = new StringBuilder();
                    foreach (var error in ee.EntityValidationErrors)
                    {
                        foreach (var thisError in error.ValidationErrors)
                        {
                            erros.Append(thisError.ErrorMessage);
                        }
                    }
                    throw new Exception(erros.ToString());
                }
                catch (Exception ex)
                {
                    string erro = ex.Message;
                }

            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                //DbSet.Include(includeProperty);
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                //return orderBy(DbSet);
                return orderBy(query);
            }
            else
            {
                //return DbSet;
                return query;
            }
        }

        public virtual TEntity FindBy(object id)
        {
            return DbSet.Find(id);
        }

        public virtual TEntity FindBy(Expression<Func<TEntity, bool>> filter, string includeProperties = "")
        {

            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {

                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {

                query = query.Include(includeProperty);
            }
            return query.FirstOrDefault(filter);
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }


        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public virtual void Delete(IEnumerable<TEntity> entityToDelete)
        {
            DbSet.RemoveRange(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public TEntity Insert(TEntity entity)
        {
            using (var context = new WeatherContext())
            {
                var dbSet = context.Set<TEntity>();

                dbSet.Add(entity);
                context.SaveChanges();
            }

            return entity;
        }

        public virtual void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
