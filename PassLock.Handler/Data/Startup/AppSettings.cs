using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace PassLock.Handler.Data.Startup
{
    public class AppSettings
    {
        private Dictionary<string, string> appSettings;

        public AppSettings(NameValueCollection appSettings)
        {
            CreateAppSettings(appSettings);
        }

        private void CreateAppSettings(NameValueCollection nameValueCollection)
        {
            appSettings = new Dictionary<string, string>();
            var keys = nameValueCollection.Keys;
            foreach (string key in keys)
            {
                string value = nameValueCollection[key];
                appSettings.Add(key, value);
            }
        }

        public string GetByKey(AppSetting setting)
        {
            string appkey = GetKeyBySetting(setting);

            if (!Exists(setting))
            {
                throw new SettingNotFoundException(appkey);
            }

            return appSettings[appkey];
        }

        public string GetByKey(string settingKey)
        {
            if (!Exists(settingKey))
            {
                throw new SettingNotFoundException(settingKey);
            }

            return appSettings[settingKey];
        }

        public bool Exists(AppSetting setting)
        {
            string settingKey = GetKeyBySetting(setting);
            return Exists(settingKey);
        }

        public bool Exists(string settingKey)
        {
            return appSettings.ContainsKey(settingKey);
        }

        private string GetKeyBySetting(AppSetting appSetting)
        {
            switch (appSetting)
            {
                case AppSetting.CheckInstallations:
                    return "CheckInstallations";
                case AppSetting.FastLogin:
                    return "FastLogin";
                default:
                    throw new ArgumentException($"The setting {appSetting} is not known");
            }
        }
    }
}
