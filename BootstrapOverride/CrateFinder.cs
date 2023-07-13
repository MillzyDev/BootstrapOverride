using System.Linq;
using MelonLoader;
using SLZ.Marrow.Warehouse;

namespace BootstrapOverride
{
    // i should totally add bootstrap support to boneject
    public static class CrateFinder
    {
        private const string _fallbackBarcode = "c2534c5a-6b79-40ec-8e98-e58c5363656e";
        private static readonly Config s_config;

        static CrateFinder()
        {
            s_config = Config.Load();
        }

        public static LevelCrateReference GetOverrideScene()
        {
            if (!string.IsNullOrEmpty(s_config.LevelName))
            {
                Crate[] crates = AssetWarehouse.Instance.GetCrates().ToArray();
                Crate? crate = crates.FirstOrDefault(crate =>
                    crate.Title.ToLower().Contains(s_config.LevelName!.ToLower()));

                s_config.LevelBarcode = crate == null ? _fallbackBarcode : crate.Barcode.ID;
            }

            if (string.IsNullOrEmpty(s_config.LevelBarcode))
                s_config.LevelBarcode = _fallbackBarcode;

            s_config.LevelName = null;
            string barcode = s_config.LevelBarcode;

            s_config.Save();

            return new LevelCrateReference(barcode);
        }
    }
}
