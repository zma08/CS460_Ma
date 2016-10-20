using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AshLoan.Startup))]
namespace AshLoan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
