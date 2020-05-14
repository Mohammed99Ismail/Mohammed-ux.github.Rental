using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VenMovie.Startup))]
namespace VenMovie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
