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

namespace MyProject.Dialogs.CategoryService
{
    /// <summary>
    /// Логика взаимодействия для CategoryListWindow.xaml
    /// </summary>
    public partial class CategoryListWindow : Window, IView
    {
        public CategoryListViewModel ViewModel => (CategoryListViewModel)this.DataContext;

        public CategoryListWindow()
        {
            InitializeComponent();
            this.DataContext = new CategoryListViewModel(this);
        }

        public void CloseDialog(bool result)
        {
            this.DialogResult = result;
            this.Close();
        }
    }
}
