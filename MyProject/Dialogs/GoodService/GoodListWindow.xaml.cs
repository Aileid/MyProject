using MyProject.Dialogs.CategoryService;
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

namespace MyProject.Dialogs.GoodService
{
    /// <summary>
    /// Логика взаимодействия для GoodListWindow.xaml
    /// </summary>
    public partial class GoodListWindow : Window, IView
    {
        public GoodListViewModel ViewModel => (GoodListViewModel)this.DataContext;

        public GoodListWindow()
        {
            InitializeComponent();
            this.DataContext = new GoodListViewModel(this);
        }

        public void CloseDialog(bool result)
        {
            this.DialogResult = result;
            this.Close();
        }
    }
}
