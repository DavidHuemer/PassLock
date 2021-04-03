using PassLock.Bitwarden.Data.Data.Objects.Items;
using PassLock.Bitwarden.Data.Data.Repositories;
using PassLock.GUI.Manager.Items;
using PassLock.GUI.ViewModels.Basics;
using System.Collections.ObjectModel;

namespace PassLock.GUI.ViewModels.MainViewModels.Pages.Items
{
    public class ItemsListViewModel : BaseViewModel
    {
        public ItemsListViewModel()
        {
            Items = BitwardenItemsRepository.Instance.Items;
        }

        private string search = "";
        public string Search
        {
            get { return search; }
            set
            {
                search = value;
                SearchItems(search);
            }
        }

        private ObservableCollection<BitwardenItem> items = new ObservableCollection<BitwardenItem>();
        public ObservableCollection<BitwardenItem> Items
        {
            get { return items; }
            set
            {
                items = value;
                SearchItems(Search);
            }
        }
        public ObservableCollection<BitwardenItem> DisplayedItems { get; set; } = new ObservableCollection<BitwardenItem>();
        public BitwardenItem SelectedItem { get; set; }

        public void SearchItems(string search)
        {
            //DisplayedItems = ItemsSearchManager.FilterItems(Items, search);
        }
    }
}
