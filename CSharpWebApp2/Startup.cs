using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSharpWebApp2.Startup))]
namespace CSharpWebApp2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
