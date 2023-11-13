using Microsoft.EntityFrameworkCore;
using MyProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core
{
    static public class CategoryList
    {
        static ApplicationContext bd = new ApplicationContext();

        static ObservableCollection<GoodModel> goods;
        static public ObservableCollection<GoodModel> Goods
        {
            get
            {
                if (goods == null)
                {
                    bd.Database.EnsureCreated();
                    bd.Goods.Load();
                    goods = bd.Goods.Local.ToObservableCollection();
                }
                return goods;
            }
        }
    }
}
