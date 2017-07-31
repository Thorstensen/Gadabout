using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gadabout.Server.Core.Data;
using Gadabout.Server.Core.Repository;

namespace Gadabout.Server.Core.Security
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IPasswordManager _passwordManager;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IPasswordManager passwordManager, IUserRepository userRepository)
        {
            _passwordManager = passwordManager;
            _userRepository = userRepository;
        }
        public bool AuthenticateUser(string userName, string password)
        {
            var persistedUser = _userRepository.GetUser(userName);
            if (persistedUser == null) return false;

            return _passwordManager.VerifyPassword(password, persistedUser.HashedPassword);
        }

        public void RegisterUser(User user)
        {
            _userRepository.Create(user);
        }

        public bool UserExists(string userName)
        {
            return _userRepository.GetUser(userName) != null;
        }
    }
}
