using Microsoft.EntityFrameworkCore;
using MyProject.Core.Dialogs.CategoryService;
using MyProject.Core.Dialogs.GoodService;
using MyProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyProject.Core.ViewModels
{
    public class GoodCoreViewModel
    {
        ApplicationContext bd = new ApplicationContext();

        public ICommand OpenGoodListCommand { get; }

        public ObservableCollection<GoodModel> Goods { get; set; }

        public GoodCoreViewModel()
        {
            bd.Database.EnsureCreated();
            bd.Goods.Load();
            this.Goods = bd.Goods.Local.ToObservableCollection();

            this.OpenGoodListCommand = new RelayCommand(p => this.OpenGoodListAction());
        }

        public void OpenGoodListAction()
        {
            IGoodDialogService service = IoC.Provide<IGoodDialogService>();

            GoodDialogResult result = service.ShowGoodListDialog();
            if (result.IsSuccess)
            {
                bd.Categorys.Load();
                this.Goods = bd.Goods.Local.ToObservableCollection();
            }
        }
    }
}
