using Gadabout.Server.Core.Data;
using Gadabout.Server.Core.Security;
using Gadabout.Server.Core.Database;
using System.Linq;

namespace Gadabout.Server.Core.Repository
{
    public class UserRepository : EntityRepository<User>, IUserRepository
    {
        private readonly IPasswordManager _passwordManager;

        public UserRepository(IPasswordManager passwordManager, IDataContext context) : base(context)
        {
            _passwordManager = passwordManager;
        }

        public override void Create(User entity)
        {
            var result = _passwordManager.GeneratePassword(entity.Password);
            entity.HashedPassword = result.Hash;
          
            base.Create(entity);
        }

        public User GetUser(string userName)
        {
            return Context.Users.FirstOrDefault(p => p.UserName == userName);
        }
    }
}
