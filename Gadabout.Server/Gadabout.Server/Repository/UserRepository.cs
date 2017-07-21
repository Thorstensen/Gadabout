using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gadabout.Server.Core.Data;
using Gadabout.Server.Core.Security;
using Gadabout.Server.Core.Extensions;
using Gadabout.Server.Core.Database;

namespace Gadabout.Server.Core.Repository
{
    public class UserRepository : EntityRepository<User>, IUserRepository
    {
        private readonly ICryptoService _cryptoService;
        private readonly IPasswordManager _passwordManager;

        public UserRepository(ICryptoService cryptoService, IPasswordManager passwordManager, IDataContext context) : base(context)
        {
            _cryptoService = cryptoService;
            _passwordManager = passwordManager;
        }

        public override void Create(User entity)
        {
            var salt = _cryptoService.GenerateSalt();
            entity.PasswordSalt = salt;
            entity.HashedPassword = _passwordManager.Hash(entity.Password + salt);
            base.Create(entity);
        }
    }
}
