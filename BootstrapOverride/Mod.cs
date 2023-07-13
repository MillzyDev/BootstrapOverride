using MelonLoader;

namespace BootstrapOverride
{
    public sealed class Mod : MelonMod
    {
        private HarmonyLib.Harmony _harmony = null!;

        public override void OnInitializeMelon()
        {
            _harmony = new HarmonyLib.Harmony($"dev.millzy.{nameof(BootstrapOverride)}");
        }

        public override void OnLateInitializeMelon()
        {
            _harmony.PatchAll();
        }

        public override void OnDeinitializeMelon()
        {
            _harmony.UnpatchSelf();
        }
    }
}
