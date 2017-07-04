using Nancy;

namespace Gadabout.Server.Nancy.Services.Module
{
    public class NancyTestPlugin : NancyModule
    {
        public NancyTestPlugin()
        {
            Get("/test", p =>
            {
                return "test-response";
            });
        }
    }
}
