using Gadabout.Server.Core.Repository;
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
        private IUserRepository _userRepository;

        public AutenticationModule(IUserRepository userRepository) : base("authentication")
        {
            _userRepository = userRepository;

            Post("/login", d =>
            {
                var body = Request.ReadHttpBody();
                var userName = body.UserName.Value;
                var user = _userRepository.GetUser(userName);

                return new Response
                {
                    StatusCode = HttpStatusCode.OK
                };
            });
        }
    }
}
