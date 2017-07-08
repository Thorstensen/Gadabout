using Gadabout.Server.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Core.Repository
{
    public interface IEntityRepository
    {
        void Create<TEntity>(TEntity entity) where TEntity : RootEntity;
        TEntity Read<TEntity>(Guid id) where TEntity : RootEntity;
        TEntity Update<TEntity>(TEntity entity) where TEntity : RootEntity;
        bool Delete<TEntity>(Guid id) where TEntity : RootEntity;
    }
}
