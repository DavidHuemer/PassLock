using PassLock.GUI.ViewModels.Basics;
using PassLock.GUI.ViewModels.MainViewModels.Pages.Items.ItemDetailViewModels;
using System.Collections.Generic;
using System.ComponentModel;

namespace PassLock.GUI.ViewModels.MainViewModels.Pages.Items
{
    public class ItemsPageViewModel : PageViewModel
    {
        public ItemsListViewModel ItemsListViewModel { get; set; }

        public List<BaseItemDetailViewModel> DetailPages { get; set; }
        public BaseItemDetailViewModel OpenedPage { get; set; }

        public ItemsPageViewModel()
        {
            DisplayName = "Items";
            ItemsListViewModel = new ItemsListViewModel();
            ItemsListViewModel.PropertyChanged += ItemsListModel_PropertyChanged;


            DetailPages = new List<BaseItemDetailViewModel>
            {
                new ItemViewerViewModel()
            };
        }

        private void ItemsListModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ItemsListViewModel.SelectedItem))
            {
                ItemViewerViewModel viewer = (ItemViewerViewModel)DetailPages[0];
                viewer.Show(ItemsListViewModel.SelectedItem);
                OpenedPage = DetailPages[0];
            }
        }
    }
}
