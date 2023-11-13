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
    /// Логика взаимодействия для GoodWindow.xaml
    /// </summary>
    public partial class GoodWindow : Window, IView
    {
        public GoodBaseViewModel ViewModel => (GoodBaseViewModel)this.DataContext;

        public GoodWindow()
        {
            InitializeComponent();
            this.DataContext = new GoodBaseViewModel(this);
        }

        public void CloseDialog(bool result)
        {
            this.DialogResult = result;
            this.Close();
        }
    }
}
