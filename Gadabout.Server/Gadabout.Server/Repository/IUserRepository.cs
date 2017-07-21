using Gadabout.Server.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Core.Repository
{
    public interface IUserRepository : IEntityRepository<User>
    {
        User GetUser(string userName);
    }
}
