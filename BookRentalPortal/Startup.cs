using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookRentalPortal.Startup))]
namespace BookRentalPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
