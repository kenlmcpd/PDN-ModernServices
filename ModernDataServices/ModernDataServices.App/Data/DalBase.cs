using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ModernDataServices.App.Models.Data;

namespace ModernDataServices.App.Data
{
    public class DalBase<TEntity> where TEntity : class
    {
        private DbContext Context { get; set; }
        public DalBase(DbContext context)
        {
            Context = context;
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public TEntity Add(TEntity enity)
        {
            return Context.Set<TEntity>().Add(enity);
        }

        public IEnumerable<TEntity> Add(List<TEntity> enities)
        {
            return Context.Set<TEntity>().AddRange(enities);
        }

        public TEntity Update(TEntity entity)
        {
            var e = Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return e;
            return entity;
        }

        public List<TEntity> Update(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Context.Set<TEntity>().Attach(entity);
            }
            return entities;
        }

        public TEntity Delete(TEntity entity)
        {
            return Context.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> Delete(List<TEntity> entities)
        {
            return Context.Set<TEntity>().RemoveRange(entities);
        }

        public TEntity First(Expression<Func<TEntity, bool>> whereClause)
        {
            return Context.Set<TEntity>().FirstOrDefault(whereClause);
        }
        

        public TEntity Last(Expression<Func<TEntity, bool>> whereClause)
        {
            return Context.Set<TEntity>().Where(whereClause).ToList().LastOrDefault();
        }

        public List<TEntity> List(Expression<Func<TEntity, bool>> whereClause)
        {
            try
            {
                return Context.Set<TEntity>().Where(whereClause).ToList();
            }
            catch (Exception ex)
            {
                var wait = ex.Message;
                throw;
            }
            
        }
        
        public Person GetPersonWithChildren(Expression<Func<Person, bool>> whereClause)
        {
            return Context.Set<Person>().Include("Addresses").Include("Phones").Include("EmailAddresses").FirstOrDefault(whereClause);
        }

        
    }
}
