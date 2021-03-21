using PassLock.GUI.ViewModels.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassLock.GUI.ViewModels.MainViewModels.Pages.Items.ItemDetailViewModels
{
    public abstract class BaseItemDetailViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Notes { get; set; }
    }
}
