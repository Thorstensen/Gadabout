using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gadabout.Server.Core.Data;
using Gadabout.Server.Core.Database;

namespace Gadabout.Server.Core.Repository
{
    /// <summary>
    /// Base CRUD repository for database transactions
    /// </summary>
    public abstract class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : RootEntity
    {
        protected readonly IDataContext Context;
        public EntityRepository(IDataContext context)
        {
            Context = context;
        }

        public virtual void Create(TEntity entity)
        {
            var context = (DataContext)Context;
            var set = context.Set<TEntity>();
            set.Add(entity);
            context.SaveChanges();
        }

        public virtual bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Read(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
