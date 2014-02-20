using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookManager.Startup))]
namespace BookManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
