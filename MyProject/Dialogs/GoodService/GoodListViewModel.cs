using MyProject.Core.Dialogs.CategoryService;
using MyProject.Core.Models;
using MyProject.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyProject.Core.Dialogs.GoodService;
using Microsoft.EntityFrameworkCore;

namespace MyProject.Dialogs.GoodService
{
    public class GoodListViewModel: GoodBaseViewModel
    {
        ApplicationContext bd = new ApplicationContext();

        public ICommand AddGoodCommand { get; }

        public ICommand DeleteGoodCommand { get; }

        public ICommand UpdateGoodCommand { get; }

        public ObservableCollection<GoodModel> Goods { get; set; }

        public GoodListViewModel(IView view) : base(view)
        {
            bd.Database.EnsureCreated();
            bd.Goods.Load();
            this.Goods = bd.Goods.Local.ToObservableCollection();

            this.AddGoodCommand = new RelayCommand(p => this.AddGoodAction());
            this.DeleteGoodCommand = new RelayCommand(p => this.UpdateGoodAction());
            this.UpdateGoodCommand = new RelayCommand(p => this.DeleteGoodAction(p));
        }

        public void AddGoodAction()
        {
            // If all is well, this should return an instance of UserDialogService, in API form!
            IGoodDialogService service = IoC.Provide<IGoodDialogService>();

            GoodDialogResult result = service.ShowGoodDialog();
            if (result.IsSuccess)
            { // ignore failed attempts/cancelled

                // add new user!
                bd.Goods.Add(new GoodModel() {
                    UPC=result.UPC,
                    Name=result.Name,
                    IDcategory=result.IDcategory,
                    Cost=result.Cost,
                    Count=result.Count,
                    DeliveryDate=result.DeliveryDate,
                    ExpirationDate=result.ExpirationDate,
                    ProductionDate=result.ProductionDate});
                bd.SaveChanges();
            }
        }

        public void UpdateGoodAction()
        {

        }

        public void DeleteGoodAction(object? p)
        {
                
        }
    }
}
