using System;
using System.Configuration;
using System.Windows.Forms;

namespace QuoteOfTheDay
{
    public class PluginAppSettings : IDisposable
    {
        private Configuration _DLLConfig = null;

        private Configuration DLLConfig
        {
            get
            {
                if (_DLLConfig != null) return _DLLConfig;

                Configuration oConfiguration = null;
                string exeConfigPath = this.GetType().Assembly.Location;
                try
                {
                    oConfiguration = ConfigurationManager.OpenExeConfiguration(exeConfigPath);
                }
                catch (Exception ex)
                {
                    //handle errror here.. means DLL has no sattelite configuration file.
                    MessageBox.Show("Error while trying to load Plugin Configuration file for Quote of the Day. " +
                               ex.Message);
                }

                _DLLConfig = oConfiguration;

                return _DLLConfig;
            }
        }

        public Boolean GetBoolean(String key)
        {
            Boolean bAppSetting;

            Boolean.TryParse(GetString(key), out bAppSetting);

            return bAppSetting;
        }

        public int GetInt(String key)
        {
            int iAppSetting;

            int.TryParse(GetString(key), out iAppSetting);

            return iAppSetting;
        }

        public Decimal GetDecimal(String key)
        {
            Decimal dAppSetting;

            Decimal.TryParse(GetString(key), out dAppSetting);

            return dAppSetting;
        }

        public string GetString(string key)
        {
            // We will use the Plugin's App.config file if it exists AND it contains a key/value pair
            KeyValueConfigurationElement element = DLLConfig?.AppSettings.Settings[key];
            if (!string.IsNullOrEmpty(element?.Value))
                return element.Value;

            // Fall back to the application's app.config file
            if (ConfigurationManager.AppSettings[key] != null)
            {
                return ConfigurationManager.AppSettings[key];
            }

            return string.Empty;
        }

        public void Dispose()
        {
            _DLLConfig = null;
        }
    }
}