using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyMvcProject.DataAccess.Abstract;
using MyMvcProject.Entity.Abstract;

namespace MyMvcProject.DataAccess.Concrete.EntityFramework
{
    public class EntityRepositoryBase<T, TContext> : IEntityRepository<T>
        where T : class, IEntity, new()
        where TContext : DbContext, new()
    {

        public List<T> GetAll()
        {
            TContext context = new TContext();
            return context.Set<T>().ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
            TContext context = new TContext();
            return (context.Set<T>().Where(filter).ToList());
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<T>().SingleOrDefault(filter);
            }
        }

        public void Add(T entity)
        {
            TContext context = new TContext();
            var entyEntity = context.Entry(entity);
            entyEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            using (TContext context = new TContext())
            {
                var entyEntity = context.Entry(entity);
                entyEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (TContext context = new TContext())
            {
                var entyEntity = context.Entry(entity);
                entyEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
