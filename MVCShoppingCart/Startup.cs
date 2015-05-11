using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCShoppingCart.Startup))]
namespace MVCShoppingCart
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
