using Microsoft.EntityFrameworkCore;
using MyProject.Core;
using MyProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyProject.Dialogs.GoodService
{
    public class GoodBaseViewModel: GoodModel
    {
        ApplicationContext bd = new ApplicationContext();

        public ICommand OKCommand { get; }
        public ICommand CancelCommand { get; }

        public IView View { get; }

        public ObservableCollection<CategoryModel> Categorys { get; set; }

        public GoodBaseViewModel(IView view)
        {
            bd.Database.EnsureCreated();
            bd.Categorys.Load();
            this.Categorys = bd.Categorys.Local.ToObservableCollection();

            this.View = view;

            this.OKCommand = new RelayCommand(p => this.OkAction());
            this.CancelCommand = new RelayCommand(p => this.CancelAction());
            
        }

        public void OkAction()
        {
            this.View.CloseDialog(true); // close it with a successful result
        }

        public void CancelAction()
        {
            this.View.CloseDialog(false); // close it with a failed result
        }
    }
}
