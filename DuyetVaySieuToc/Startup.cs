using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DuyetVaySieuToc.Startup))]
namespace DuyetVaySieuToc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
