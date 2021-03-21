using System;

namespace PassLock.Handler.Data.Startup
{
    public class SettingNotFoundException : Exception
    {
        public SettingNotFoundException(string setting) : base($"The setting {setting} was not found")
        {
            
        }
    }
}
