using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gadabout.Server.Core.Data;

namespace Gadabout.Server.Core.Repository
{
    /// <summary>
    /// Base CRUD repository for database transactions
    /// </summary>
    public class EntitiesRepository : IEntitiesRepository
    {

        public void Create<TEntity>(TEntity entity) where TEntity : RootEntity
        {
            throw new NotImplementedException();
        }

        public bool Delete<TEntity>(long id) where TEntity : RootEntity
        {
            throw new NotImplementedException();
        }

        public TEntity Read<TEntity>(long id) where TEntity : RootEntity
        {
            throw new NotImplementedException();
        }

        public TEntity Update<TEntity>(TEntity entity) where TEntity : RootEntity
        {
            throw new NotImplementedException();
        }
    }
}
