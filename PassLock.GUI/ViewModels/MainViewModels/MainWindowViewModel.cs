using MVVM.Tools;
using PassLock.GUI.ViewModels.Basics;
using PassLock.GUI.ViewModels.MainViewModels.Pages.Account;
using PassLock.GUI.ViewModels.MainViewModels.Pages.Items;
using PassLock.GUI.ViewModels.MainViewModels.Pages.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace PassLock.GUI.ViewModels.MainViewModels
{
    public class MainWindowViewModel : WindowViewModel
    {
        public MainWindowViewModel()
        {
            Title = "PassLock";

            Pages.Add(new ItemsPageViewModel());
            Pages.Add(new SettingsPageViewModel());
            Pages.Add(new AccountPageViewModel());
            CurrentPage = Pages[0];
        }

        public List<PageViewModel> Pages { get; set; } = new List<PageViewModel>();
        public PageViewModel CurrentPage { get; set; }

        public RelayCommand<PageViewModel> ChangePage => new RelayCommand<PageViewModel>(o => { DoChangePage(o); }, o => true);
        
        private void DoChangePage(PageViewModel o)
        {
            Console.WriteLine($"Change current page to {o.DisplayName}");
            CurrentPage = Pages.FirstOrDefault(x => x == o);
        }
    }
}
