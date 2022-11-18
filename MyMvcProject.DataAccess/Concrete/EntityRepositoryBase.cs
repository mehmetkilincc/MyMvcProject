using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyMvcProject.DataAccess.Abstract;

namespace MyMvcProject.DataAccess.Concrete
{
    public class EntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {

        public List<TEntity> GetAll()
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var entyEntity = context.Entry(entity);
                entyEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var entyEntity = context.Entry(entity);
                entyEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
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
