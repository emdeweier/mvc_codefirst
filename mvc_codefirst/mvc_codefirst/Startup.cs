using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvc_codefirst.Startup))]
namespace mvc_codefirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
