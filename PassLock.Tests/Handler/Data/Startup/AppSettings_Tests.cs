using PassLock.Handler.Data.Startup;
using System.Collections.Specialized;
using Xunit;

namespace PassLock.Tests.Handler.Data.Startup
{
    public class AppSettings_Tests
    {
        private const string CHECK_INSTALLATIONS_VALUE = "true";


        [Theory]
        [InlineData("Setting1", "SettingValue1")]
        [InlineData("CheckInstallations", "true")]
        public void CorrectValues_Tests(string key, string expected)
        {
            var appSettings = CreateAppSettings();
            string value = appSettings.GetByKey(key);
            Assert.Equal(expected, value);
        }

        [Fact]
        public void CheckAppSetting()
        {
            var appSettings = CreateAppSettings();
            string value = appSettings.GetByKey(AppSetting.CheckInstallations);
            Assert.Equal(CHECK_INSTALLATIONS_VALUE, value);
        }

        [Fact]
        public void CheckUnknownString()
        {
            var appSettings = CreateAppSettings();
            Assert.Throws<SettingNotFoundException>(() => appSettings.GetByKey("NotExisting"));
        }

        [Theory]
        [InlineData("Setting1", true)]
        [InlineData("CheckInstallations", true)]
        [InlineData("NotExisting", false)]
        public void ExitsString(string key, bool expected)
        {
            var appSettings = CreateAppSettings();
            Assert.Equal(expected, appSettings.Exists(key));
        }

        [Fact]
        public void ShouldExist()
        {
            var appSettings = CreateAppSettings();
            Assert.True(appSettings.Exists(AppSetting.CheckInstallations));
        }

        [Fact]
        public void ShouldNotExist()
        {
            var appSettings = new AppSettings(new NameValueCollection());
            Assert.False(appSettings.Exists(AppSetting.CheckInstallations));
        }

        [Fact]
        public void CheckUnknownAppSetting()
        {
            var appSettings = new AppSettings(new NameValueCollection());
            Assert.Throws<SettingNotFoundException>(() => appSettings.GetByKey(AppSetting.CheckInstallations));
        }

        private AppSettings CreateAppSettings()
        {
            var collection = new NameValueCollection
            {
                { "Setting1", "SettingValue1" },
                { "CheckInstallations", CHECK_INSTALLATIONS_VALUE }
            };

            return new AppSettings(collection);
        }
    }
}
