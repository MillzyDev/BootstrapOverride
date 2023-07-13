using System;
using HarmonyLib;
using SLZ.Bonelab;
using SLZ.Marrow.Warehouse;

namespace BootstrapOverride.HarmonyPatches
{
    [HarmonyPatch(typeof(SceneBootstrapper_Bonelab))]
    [HarmonyPatch(nameof(SceneBootstrapper_Bonelab.Start))]
    // ReSharper disable once InconsistentNaming
    internal static class SceneBootstrapper_BonelabPatch
    {

        [HarmonyPostfix]
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once UnusedMember.Global
        public static void Postfix(SceneBootstrapper_Bonelab __instance)
        {
            AssetWarehouse.OnReady((Action)(() =>
            {
                LevelCrateReference levelCrateReference = CrateFinder.GetOverrideScene();
                __instance.MenuHollowCrateRef = levelCrateReference;
                __instance.VoidG114CrateRef = levelCrateReference;
            }));
        }
    }
}
