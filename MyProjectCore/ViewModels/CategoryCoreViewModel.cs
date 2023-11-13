using Microsoft.EntityFrameworkCore;
using MyProject.Core.Dialogs.CategoryService;
using MyProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyProject.Core.ViewModels
{
    public class CategoryCoreViewModel: BaseViewModel
    {
        ApplicationContext bd = new ApplicationContext();

        public ICommand OpenCategoryListCommand { get; }

        public ObservableCollection<CategoryModel> Categorys { get; set; }

        public CategoryCoreViewModel()
        {
            bd.Database.EnsureCreated();
            bd.Categorys.Load();
            this.Categorys = bd.Categorys.Local.ToObservableCollection();

            this.OpenCategoryListCommand = new RelayCommand(p => this.OpenCategoryListAction());
        }

        public void OpenCategoryListAction()
        {
            ICategoryDialogService service = IoC.Provide<ICategoryDialogService>();

            CategoryDialogResult result = service.ShowCategoryListDialog();

            bd.Categorys.Load();
            this.Categorys = bd.Categorys.Local.ToObservableCollection();
        }
    }
}
