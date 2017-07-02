using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Gadabout.Server.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HostFactory.Run(configure =>
            {
                configure.Service<GadaboutApp>(gadabout =>
                {
                    gadabout.ConstructUsing(app => new GadaboutApp());
                    gadabout.WhenStarted(cfg => cfg.Start());
                    gadabout.WhenStopped(cfg => cfg.Stop());
                });

                configure.OnException(exception =>
                {
                    
                });

                configure.SetDescription("Gadabout Server responsible for hosting Web Services and database transactions");
                configure.SetDisplayName("Gadabout Server");
                configure.SetServiceName("Gadabout Server");
            });
        }
    }
}
