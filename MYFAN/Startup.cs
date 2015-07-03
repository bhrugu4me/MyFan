using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MYFAN.Presentation.Startup))]
namespace MYFAN.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
