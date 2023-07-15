using Boneject;
using Boneject.Attributes;
using BootstrapOverride.Configuration;
using BootstrapOverride.Modules;

namespace BootstrapOverride
{
    public sealed class Mod : InjectableMelonMod
    {
        [OnInitialize]
        // ReSharper disable once UnusedMember.Global
        public void OnInitializeMod(Bonejector bonejector)
        {
            Config config = Config.Load();
            
            bonejector.Load<BOAppModule>(Context.App, config);
            bonejector.Load<BOSceneBootstrapperModule>(Context.SceneBootstrapper);
        }
    }
}
