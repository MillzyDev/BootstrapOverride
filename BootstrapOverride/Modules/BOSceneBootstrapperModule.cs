using Boneject.Extensions;
using BootstrapOverride.Managers;
using Ninject.Modules;

namespace BootstrapOverride.Modules
{
    public class BOSceneBootstrapperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<LevelCrateManager>().ToSelf().InSingletonScope();
            this.BindMonoBehaviourOnNewGameObject<LevelOverrider>().InSingletonScope(); // NonLazy
        }
    }
}
