using System.IO;
using MelonLoader;
using Newtonsoft.Json;

namespace BootstrapOverride.Configuration
{
    public sealed class Config
    {
        private static readonly string s_configPath =
            Path.Combine(MelonUtils.UserDataDirectory, $"{nameof(BootstrapOverride)}.json");

        #region Properties

        [JsonProperty("level_barcode")]
        public string LevelBarcode { get; set; } = "c2534c5a-6b79-40ec-8e98-e58c5363656e";

        [JsonProperty("level_name")]
        public string? LevelName { get; set; }

        #endregion

        public static Config Load()
        {
            if (!File.Exists(s_configPath))
            {
                var defaultConfig = new Config();
                string json = JsonConvert.SerializeObject((defaultConfig, Formatting.Indented));
                File.WriteAllText(s_configPath, json);
                return defaultConfig;
            }

            string file = File.ReadAllText(s_configPath);
            var config = JsonConvert.DeserializeObject<Config>(file);
            return config!;
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(s_configPath, json);
        }
    }
}
