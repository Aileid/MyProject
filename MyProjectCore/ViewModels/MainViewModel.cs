using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MyProject.Core.Dialogs.CategoryService;
using MyProject.Core.Dialogs.GoodService;
using MyProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace MyProject.Core.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        ApplicationContext bd = new ApplicationContext();

        public ICommand OpenCategoryListCommand { get; }
        public ICommand AddGoodCommand { get; }
        public ICommand DeleteGoodCommand { get; }
        public ICommand EditeGoodCommand { get; }

        public ObservableCollection<GoodModel> Goods { get; set; }
        public ObservableCollection<CategoryModel> Categorys { get; set; }

        CategoryModel filter;
        public CategoryModel Filter {

            get => filter;

            set { RaisePropertyChanged(ref filter, value); YourFilteredCollection.Refresh(); }
        }

        public ICollectionView YourFilteredCollection
        {
            set { }
            get
            {
                var source = CollectionViewSource.GetDefaultView(Goods);
                if (Filter == null || Filter.Name == "Все") { source.Filter = null; return source; }
                source.Filter =  p => ((GoodModel)p).IDcategory == Filter.IDcategory;
                return source;
            }
        }

        public MainViewModel()
        {
            bd.Database.EnsureCreated();
            
            bd.Goods.Load();
            this.Goods = bd.Goods.Local.ToObservableCollection();
            bd.Categorys.Load();
            this.Categorys = bd.Categorys.Local.ToObservableCollection();
            if (Categorys.Where(x => x.Name == "Все").Count() == 0) Categorys.Add(new CategoryModel() { IDcategory = 0, Name = "Все" });

            //YourFilteredCollection = CollectionViewSource.GetDefaultView(Goods);

            this.OpenCategoryListCommand = new RelayCommand(p=> this.OpenCategoryListAction());
            this.AddGoodCommand = new RelayCommand(p=>this.AddGoodAction());
            this.DeleteGoodCommand = new RelayCommand(p=>this.DeleteGoodAction(p)); 
            this.EditeGoodCommand = new RelayCommand(p => this.UpdateGoodAction(p));
        }

        void RefreshCategorys()
        {
            bd.Categorys.Load();
            
            if (Categorys.Where(x => x.Name == "Все").Count() == 0) Categorys.Add(new CategoryModel() { IDcategory = 0, Name = "Все" });
            this.Categorys = bd.Categorys.Local.ToObservableCollection();
        }

        public void OpenCategoryListAction()
        {
            ICategoryDialogService service = IoC.Provide<ICategoryDialogService>();

            CategoryDialogResult result = service.ShowCategoryListDialog();

            RefreshCategorys();
        }

        public void AddGoodAction()
        {
            IGoodDialogService service = IoC.Provide<IGoodDialogService>();

            GoodDialogResult result = service.ShowGoodDialog();
            if (result.IsSuccess)
            { // ignore failed attempts/cancelled

                // add new user!
                bd.Goods.Add(new GoodModel()
                {
                    UPC = result.UPC,
                    Name = result.Name,
                    IDcategory = result.IDcategory,
                    Cost = result.Cost,
                    Count = result.Count,
                    DeliveryDate = result.DeliveryDate,
                    ExpirationDate = result.ExpirationDate,
                    ProductionDate = result.ProductionDate
                });
                bd.SaveChanges();
            }
        }

        void DeleteGoodAction(object? p)
        {
            if (p == null) return;
            GoodModel good = p as GoodModel;
            bd.Goods.Remove(good);
            bd.SaveChanges();
        }

        void UpdateGoodAction(object? p)
        {
            IGoodDialogService service = IoC.Provide<IGoodDialogService>();

            GoodDialogResult result = service.ShowGoodDialog(p);
            if (result.IsSuccess)
            {
                GoodModel good = (GoodModel)p;
                good.Name = result.Name;
                good.IDcategory = result.IDcategory;
                good.Cost = result.Cost;
                good.Count = result.Count;
                good.DeliveryDate = result.DeliveryDate;
                good.ProductionDate = result.ProductionDate;
                good.ExpirationDate = result.ExpirationDate;
                good.UPC = result.UPC;
                bd.Goods.Update(good);
                bd.SaveChanges();
            }
        }
        
}
}
