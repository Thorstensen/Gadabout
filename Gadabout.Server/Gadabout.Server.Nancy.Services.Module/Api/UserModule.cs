using Gadabout.Server.Core.Data;
using Gadabout.Server.Core.Database;
using Gadabout.Server.Core.Repository;
using Gadabout.Server.Nancy.Core.Framework;
using Nancy;
using Nancy.Extensions;
using Nancy.IO;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Nancy.Services.Module.Api
{
    public class UserModule : NancyBaseModule
    {
        private readonly IEntityRepository _entityRepository;

        public UserModule(IEntityRepository entityRepository) : base("users")
        {
            _entityRepository = entityRepository;

            Post("/new", d =>
            {
                var user = this.Bind<User>();
                _entityRepository.Create(user);

                return new Response
                {
                    StatusCode = HttpStatusCode.OK
                };
            });
        }
    }
}
