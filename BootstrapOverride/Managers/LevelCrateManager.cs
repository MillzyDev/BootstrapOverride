using System.Linq;
using BootstrapOverride.Configuration;
using Ninject;
using SLZ.Marrow.Warehouse;

namespace BootstrapOverride.Managers
{
    public class LevelCrateManager
    {
        private const string _fallbackBarcode = "c2534c5a-6b79-40ec-8e98-e58c5363656e";
        private readonly Config _config;
        
        [Inject]
        public LevelCrateManager(Config config)
        {
            _config = config;
        }

        public LevelCrateReference GetOverrideLevel()
        {
            if (!string.IsNullOrEmpty(_config.LevelName))
            {
                Crate[] crates = AssetWarehouse.Instance.GetCrates().ToArray();
                Crate? crate = crates.FirstOrDefault(crate =>
                    crate.Title.ToLower().Contains(_config.LevelName!.ToLower()));

                _config.LevelBarcode = crate == null ? _fallbackBarcode : crate.Barcode.ID;
            }

            if (string.IsNullOrEmpty(_config.LevelBarcode))
                _config.LevelBarcode = _fallbackBarcode;
            
            _config.LevelName = string.Empty;
            _config.Save();

            return new LevelCrateReference(_config.LevelBarcode);
        }
    }
}
