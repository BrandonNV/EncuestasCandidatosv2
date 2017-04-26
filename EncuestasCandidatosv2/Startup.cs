using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EncuestasCandidatosv2.Startup))]
namespace EncuestasCandidatosv2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
