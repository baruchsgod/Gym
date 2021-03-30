using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gym.Startup))]
namespace Gym
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
