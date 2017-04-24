using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrainingVisit.Startup))]
namespace TrainingVisit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
