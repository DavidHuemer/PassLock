using PassLock.GUI.ViewModels.Basics;
using PassLock.GUI.ViewModels.MainViewModels.Pages;
using System.ComponentModel;

namespace PassLock.GUI.ViewModels.MainViewModels
{
    public class MainWindowViewModel : WindowViewModel
    {
        public NavigationViewModel NavigationViewModel { get; set; }
        public PageViewModel CurrentPage { get; set; }

        public MainWindowViewModel()
        {
            Title = "PassLock";

            NavigationViewModel = new NavigationViewModel();
            NavigationViewModel.PropertyChanged += Navigation_PropChanged;
        }

        private void Navigation_PropChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(NavigationViewModel.CurrentPage))
            {
                CurrentPage = NavigationViewModel.CurrentPage;
            }
        }
    }
}
