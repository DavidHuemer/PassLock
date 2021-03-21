using PassLock.GUI.ViewModels.MainViewModels.Pages.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PassLock.GUI.Pages.MainWindowPages.ItemsPages
{
    /// <summary>
    /// Interaction logic for ItemsPage.xaml
    /// </summary>
    public partial class ItemsPage : UserControl
    {
        public ItemsPage()
        {
            InitializeComponent();
            Image image;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var model = DataContext as ItemsPageViewModel;
        }
    }
}
