using MyProject.Core;
using MyProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyProject.Dialogs.CategoryService
{
    public class CategoryBaseViewModel: CategoryModel
    {
        public ICommand OKCommand { get; }
        public ICommand CancelCommand { get; }

        public IView View { get; }

        public CategoryBaseViewModel(IView view)
        {
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
