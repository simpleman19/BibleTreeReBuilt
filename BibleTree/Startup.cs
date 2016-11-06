using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BibleTree.Startup))]
namespace BibleTree
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
