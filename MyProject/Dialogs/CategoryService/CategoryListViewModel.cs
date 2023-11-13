using MyProject.Core;
using MyProject.Core.Dialogs.CategoryService;
using MyProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;

namespace MyProject.Dialogs.CategoryService
{
    public class CategoryListViewModel : CategoryBaseViewModel
    {
        ApplicationContext bd = new ApplicationContext();

        public ICommand AddCategoryCommand { get; }

        public ICommand DeleteCategoryCommand { get; }

        public ICommand UpdateCategoryCommand { get; }

        public ObservableCollection<CategoryModel> Categorys { get; set; }

        public CategoryListViewModel(IView view) : base(view)
        {
            bd.Database.EnsureCreated();
            bd.Categorys.Load();
            this.Categorys = bd.Categorys.Local.ToObservableCollection();

            this.AddCategoryCommand = new RelayCommand(p => this.AddCategoryAction());
            this.DeleteCategoryCommand = new RelayCommand(p=>this.DeleteCategoryAction(p));
            this.UpdateCategoryCommand = new RelayCommand(p => this.UpdateCategoryAction(p));
        }

        public void AddCategoryAction()
        {
            // If all is well, this should return an instance of UserDialogService, in API form!
            ICategoryDialogService service = IoC.Provide<ICategoryDialogService>();

            CategoryDialogResult result = service.ShowCategoryDialog();
            if (result.IsSuccess)
            { // ignore failed attempts/cancelled

                // add new user!
                bd.Categorys.Add(new CategoryModel() { Name = result.Name });
                bd.SaveChanges();
            }
        }

        public void UpdateCategoryAction(object? p)
        {
            ICategoryDialogService service = IoC.Provide<ICategoryDialogService>();

            CategoryDialogResult result = service.ShowCategoryDialog(p);
            if (result.IsSuccess)
            {
                CategoryModel category = (CategoryModel)p;
                category.Name = result.Name;
                bd.Categorys.Update(category);
                bd.SaveChanges();
            }
        }

        public void DeleteCategoryAction(object? p)
        {
            if (p == null) return;
            CategoryModel category = p as CategoryModel;
            bd.Categorys.Remove(category);
            bd.SaveChanges();
        }
    }
}
