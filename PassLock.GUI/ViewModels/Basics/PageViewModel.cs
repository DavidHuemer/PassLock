using PassLock.GUI.Resources;
using System.Windows;

namespace PassLock.GUI.ViewModels.Basics
{
    public class PageViewModel : BaseViewModel
    {
        public PageViewModel(string displayName, string iconsResource)
        {
            DisplayName = displayName;
            IconsResource = ResourceHandler.Get<DataTemplate>(iconsResource);
        }

        public string DisplayName { get; set; }

        public DataTemplate IconsResource { get; set; }

        public int? ItemsCount { get; set; } = null;
    }
}
