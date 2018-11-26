using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace FirewallMan
{
    class Settings
    {
        private static readonly Settings instance = new Settings();
        private Dictionary<string, string> SettingsDictionary = new Dictionary<string, string>();

        private Settings()
        { }

        public static Settings GetSettings()
        {
            return instance;
        }

        public bool SaveSettings(string fileLocation)
        {
            try
            {
                File.WriteAllText(fileLocation, JsonConvert.SerializeObject(SettingsDictionary));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool LoadSettings(string fileLocation)
        {
            try
            {
                JsonConvert.DeserializeObject(File.ReadAllText(fileLocation));
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
