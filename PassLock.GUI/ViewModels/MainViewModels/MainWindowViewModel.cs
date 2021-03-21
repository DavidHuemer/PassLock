using PassLock.GUI.ViewModels.Basics;
using PassLock.GUI.ViewModels.MainViewModels.Pages.Items;
using PassLock.GUI.ViewModels.MainViewModels.Pages.Settings;
using System.Collections.Generic;

namespace PassLock.GUI.ViewModels.MainViewModels
{
    public class MainWindowViewModel : WindowViewModel
    {
        public MainWindowViewModel()
        {
            Title = "PassLock";

            Pages.Add(new ItemsPageViewModel());
            Pages.Add(new SettingsPageViewModel());
            CurrentPage = Pages[0];
        }

        public List<PageViewModel> Pages { get; set; } = new List<PageViewModel>();
        public PageViewModel CurrentPage { get; set; }
    }
}
