using BootstrapOverride.Configuration;
using Ninject.Modules;

namespace BootstrapOverride.Modules
{
    public class BOAppModule : NinjectModule
    {
        private readonly Config _config;
        
        public BOAppModule(Config config)
        {
            _config = config;
        }
        
        public override void Load()
        {
            Bind<Config>().ToConstant(_config).InSingletonScope();
        }
    }
}
