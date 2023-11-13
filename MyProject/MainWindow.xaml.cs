using MyProject.Core;
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
using MyProject.Core.Dialogs.CategoryService;
using MyProject.Dialogs.CategoryService;
using MyProject.Core.Models;
using MyProject.Core.ViewModels;
using MyProject.Dialogs.GoodService;
using MyProject.Core.Dialogs.GoodService;

namespace MyProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Добавляет диалоговый сервис
            IoC.Register<ICategoryDialogService>(new CategoryDialogService());
            IoC.Register<IGoodDialogService>(new GoodDialogService());

            this.DataContext = new MainViewModel();
        }
    }
}
