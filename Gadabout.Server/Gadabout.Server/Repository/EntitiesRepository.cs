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
    public class EntityRepository : IEntityRepository
    {
        private readonly IDataContext _context;
        public EntityRepository(IDataContext context)
        {
            _context = context;
        }

        public void Create<TEntity>(TEntity entity) where TEntity : RootEntity
        {
            var context = (DataContext)_context;
            var set = context.Set<TEntity>();
            set.Add(entity);
            context.SaveChanges();
        }

        public bool Delete<TEntity>(Guid id) where TEntity : RootEntity
        {
            throw new NotImplementedException();
        }

        public TEntity Read<TEntity>(Guid id) where TEntity : RootEntity
        {
            throw new NotImplementedException();
        }

        public TEntity Update<TEntity>(TEntity entity) where TEntity : RootEntity
        {
            throw new NotImplementedException();
        }
    }
}
