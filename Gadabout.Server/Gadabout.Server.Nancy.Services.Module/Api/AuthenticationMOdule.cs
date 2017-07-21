using Gadabout.Server.Core.Repository;
using Gadabout.Server.Core.Security;
using Gadabout.Server.Nancy.Core.Extensions;
using Gadabout.Server.Nancy.Core.Framework;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Nancy.Services.Module.Api
{
    public class AutenticationModule : NancyBaseModule
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordManager _passwordManager;

        public AutenticationModule(IUserRepository userRepository, IPasswordManager passwordManager) : base("authentication")
        {
            _userRepository = userRepository;
            _passwordManager = passwordManager;

            Post("/login", d =>
            {
                var body = Request.ReadHttpBody();
                var userName = (string)body.UserName.Value;
                var password = body.Password.Value;
                var user = _userRepository.GetUser(userName);

                if (!passwordManager.VerifyPassword(password, user.HashedPassword))
                    return new Response { StatusCode = HttpStatusCode.Forbidden };

                return new Response
                {
                    StatusCode = HttpStatusCode.OK
                };
            });
        }
    }
}
