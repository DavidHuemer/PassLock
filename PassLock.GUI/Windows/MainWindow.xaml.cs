using PassLock.GUI.ViewModels.MainViewModels;
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
using System.Windows.Shapes;

namespace PassLock.GUI.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow instance;
        public static MainWindow Instance
        {
            get
            {
                if (instance == null)
                    instance = new MainWindow();
                return instance;
            }
        }

        public MainWindowViewModel MainWindowViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel = new MainWindowViewModel();
            DataContext = MainWindowViewModel;
        }
    }
}
