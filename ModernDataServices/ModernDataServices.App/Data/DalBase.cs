using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ModernDataServices.App.Models.Data;

namespace ModernDataServices.App.Data
{
    /// <summary>
    /// Data Access Layer Generic EF
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class DalBase<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        private DbContext Context { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DalBase{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public DalBase(DbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        /// <summary>
        /// Adds the specified enity.
        /// </summary>
        /// <param name="enity">The enity.</param>
        /// <returns></returns>
        public TEntity Add(TEntity enity)
        {
            return Context.Set<TEntity>().Add(enity);
        }

        /// <summary>
        /// Adds the specified enities.
        /// </summary>
        /// <param name="enities">The enities.</param>
        /// <returns></returns>
        public IEnumerable<TEntity> Add(List<TEntity> enities)
        {
            return Context.Set<TEntity>().AddRange(enities);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public TEntity Update(TEntity entity)
        {
            var e = Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return e;
            return entity;
        }

        /// <summary>
        /// Updates the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        public List<TEntity> Update(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Context.Set<TEntity>().Attach(entity);
            }
            return entities;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public TEntity Delete(TEntity entity)
        {
            return Context.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Deletes the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        public IEnumerable<TEntity> Delete(List<TEntity> entities)
        {
            return Context.Set<TEntity>().RemoveRange(entities);
        }

        /// <summary>
        /// Firsts the specified where clause.
        /// </summary>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        public TEntity First(Expression<Func<TEntity, bool>> whereClause)
        {
            return Context.Set<TEntity>().FirstOrDefault(whereClause);
        }

        /// <summary>
        /// Lasts the specified where clause.
        /// </summary>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        public TEntity Last(Expression<Func<TEntity, bool>> whereClause)
        {
            return Context.Set<TEntity>().Where(whereClause).ToList().LastOrDefault();
        }

        /// <summary>
        /// Lists the specified where clause.
        /// </summary>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the person with children.
        /// </summary>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        public Person GetPersonWithChildren(Expression<Func<Person, bool>> whereClause)
        {
            return Context.Set<Person>().Include("Addresses").Include("Phones").Include("EmailAddresses").FirstOrDefault(whereClause);
        }

        
    }
}
