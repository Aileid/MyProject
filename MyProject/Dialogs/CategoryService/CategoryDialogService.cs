using MyProject.Core.Dialogs.CategoryService;
using MyProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Dialogs.CategoryService
{
    public class CategoryDialogService: ICategoryDialogService
    {
        /// <summary>
        /// Окно для добавления и редактирования
        /// </summary>
        /// <param name="defaultUsername"></param>
        /// <returns></returns>
        public CategoryDialogResult ShowCategoryDialog(object p = null)
        {
            CategorysWindow window = new CategorysWindow();
            // set default parameters for the UI

            CategoryModel? category = p as CategoryModel;
            window.ViewModel.Name = category?.Name ?? "Новая категория";

            bool result = window.ShowDialog() == true; // ShowDialog() returns a nullable bool

            if (!result)
            {
                // При неудаче возвращает пустой объект с кодом неудачи
                return new CategoryDialogResult() { IsSuccess = false };
            }

            return new CategoryDialogResult()
            {
                IDcategory = window.ViewModel.IDcategory,
                Name = window.ViewModel.Name,
                IsSuccess = true
            };
        }

        // async so that it can await the dispatcher
        public async Task<CategoryDialogResult> ShowCategoryDialogAsync(object category = null)
        {
            return await App.Current.Dispatcher.InvokeAsync(() => {
                return ShowCategoryDialog(category);
            });
        }

        /// <summary>
        /// окно со списком для взаимодействий
        /// </summary>
        /// <param name="defaultUsername"></param>
        /// <returns></returns>
        public CategoryDialogResult ShowCategoryListDialog()
        {
            CategoryListWindow window = new CategoryListWindow();
            // set default parameters for the UI
            

            bool result = window.ShowDialog() == true; // ShowDialog() returns a nullable bool

            if (!result)
            {
                // При неудаче возвращает пустой объект с кодом неудачи
                return new CategoryDialogResult() { IsSuccess = false };
            }

            return new CategoryDialogResult()
            {
                IDcategory = window.ViewModel.IDcategory,
                Name = window.ViewModel.Name,
                IsSuccess = true
            };
        }

        // async so that it can await the dispatcher
        public async Task<CategoryDialogResult> ShowCategoryListDialogAsync()
        {
            return await App.Current.Dispatcher.InvokeAsync(() => {
                return ShowCategoryListDialog();
            });
        }
    }
}
