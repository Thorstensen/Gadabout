using Gadabout.Server.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Core.Repository
{
    public interface IEntityRepository<TEntity> where TEntity : RootEntity
    {
        void Create(TEntity entity);
        TEntity Read(Guid id);
        TEntity Update(TEntity entity);
        bool Delete(Guid id);
    }
}
