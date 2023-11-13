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
    /// Логика взаимодействия для CategorysWindow.xaml
    /// </summary>
    public partial class CategorysWindow : Window, IView
    {
        public CategoryBaseViewModel ViewModel => (CategoryBaseViewModel)this.DataContext;
        
        public CategorysWindow()
        {
            InitializeComponent();
            this.DataContext = new CategoryBaseViewModel(this);
        }

        public void CloseDialog(bool result)
        {
            this.DialogResult = result;
            this.Close();
        }
    }
}
