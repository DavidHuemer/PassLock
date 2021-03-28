using PassLock.Bitwarden.Data.Data.Objects.Items;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PassLock.GUI.ViewModels.MainViewModels.Pages.Items.ItemDetailViewModels
{
    public class ItemViewerViewModel : BaseItemDetailViewModel
    {
        public ItemViewerViewModel()
        {
            Title = "";
        }

        private BitwardenItem item;
        public BitwardenItem Item
        {
            get { return item; }
            set
            {
                item = value;
                //if(item != null)
                //{
                //    IconSource = item.IconSource;
                //    Name = item.Name;
                //    Username = item.Login.Username;
                //    Password = item.Login.Password;
                //    Notes = item.Notes;
                //    Websites = GetWebsites(item.Login.Uris);
                //}
            }
        }

        private ObservableCollection<KeyValuePair<string, string>> GetWebsites(List<string> uris)
        {
            var pairs = new ObservableCollection<KeyValuePair<string, string>>();

            for (int i = 0; i < uris.Count; i++)
            {
                pairs.Add(new KeyValuePair<string, string>($"Website {i + 1}", uris[i]));
            }

            return pairs;
        }

        public string IconSource { get; set; }

        public ObservableCollection<KeyValuePair<string, string>> Websites { get; set; }



        public void Show(BitwardenItem item)
        {
            Item = item;
        }
    }
}
