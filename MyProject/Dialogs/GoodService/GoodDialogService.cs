using MyProject.Core.Dialogs.CategoryService;
using MyProject.Core.Dialogs.GoodService;
using MyProject.Core.Models;
using MyProject.Dialogs.CategoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyProject.Dialogs.GoodService
{
    public class GoodDialogService: IGoodDialogService
    {
        /// <summary>
        /// Окно для добавления и редактирования
        /// </summary>
        /// <param name="defaultUsername"></param>
        /// <returns></returns>
        public GoodDialogResult ShowGoodDialog(object? p = null)
        {
            GoodWindow window = new GoodWindow();

            GoodModel? good = p as GoodModel;
            if (good != null)
            {
                window.ViewModel.Name = good?.Name;
                window.ViewModel.UPC = good.UPC;
                window.ViewModel.IDgood = good.IDgood;
                window.ViewModel.Cost = good.Cost;
                window.ViewModel.Count = good.Count;
                window.ViewModel.DeliveryDate = good.DeliveryDate;
                window.ViewModel.ExpirationDate = good.ExpirationDate;
                window.ViewModel.ProductionDate = good.ProductionDate;
                window.ViewModel.IDcategory = good.IDcategory;
            }

            bool result = window.ShowDialog() == true; // ShowDialog() returns a nullable bool

            if (!result)
            {
                // При неудаче возвращает пустой объект с кодом неудачи
                return new GoodDialogResult() { IsSuccess = false };
            }

            return new GoodDialogResult()
            {
                IDgood = window.ViewModel.IDgood,
                UPC = window.ViewModel.UPC,
                Name = window.ViewModel.Name,
                Cost = window.ViewModel.Cost,
                Count = window.ViewModel.Count,
                DeliveryDate = window.ViewModel.DeliveryDate,
                ExpirationDate = window.ViewModel.ExpirationDate,
                ProductionDate = window.ViewModel.ProductionDate,
                IDcategory = window.ViewModel.IDcategory,

                IsSuccess = true
            };
        }

        // async so that it can await the dispatcher
        public async Task<GoodDialogResult> ShowGoodDialogAsync(object? p = null)
        {
            return await App.Current.Dispatcher.InvokeAsync(() => {
                return ShowGoodDialog(p);
            });
        }

        /// <summary>
        /// окно со списком для взаимодействий
        /// </summary>
        /// <param name="defaultUsername"></param>
        /// <returns></returns>
        public GoodDialogResult ShowGoodListDialog()
        {
            GoodListWindow window = new GoodListWindow();

            bool result = window.ShowDialog() == true; // ShowDialog() returns a nullable bool

            if (!result)
            {
                // При неудаче возвращает пустой объект с кодом неудачи
                return new GoodDialogResult() { IsSuccess = false };
            }

            return new GoodDialogResult()
            {
                IDgood = window.ViewModel.IDgood,
                UPC = window.ViewModel.UPC,
                Name = window.ViewModel.Name,
                Cost = window.ViewModel.Cost,
                Count = window.ViewModel.Count,
                DeliveryDate = window.ViewModel.DeliveryDate,
                ExpirationDate = window.ViewModel.ExpirationDate,
                ProductionDate = window.ViewModel.ProductionDate,
                IDcategory = window.ViewModel.IDcategory,

                IsSuccess = true
            };
        }

        // async so that it can await the dispatcher
        public async Task<GoodDialogResult> ShowGoodListDialogAsync()
        {
            return await App.Current.Dispatcher.InvokeAsync(() => {
                return ShowGoodListDialog();
            });
        }
    }
}
