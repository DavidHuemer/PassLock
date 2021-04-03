using System.Windows;

namespace PassLock.GUI.Resources
{
    public static class ResourceHandler
    {
        public static T Get<T>(string resourceName) where T : class
        {
            return (T)Application.Current.TryFindResource(resourceName);
        }
    }
}
