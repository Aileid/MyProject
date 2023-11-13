using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Dialogs.CategoryService
{
    public interface ICategoryDialogService
    {
        // Асинхронная версия это делегат не асинхронной
        Task<CategoryDialogResult> ShowCategoryDialogAsync(object category = null);

        CategoryDialogResult ShowCategoryDialog(object category = null);

        Task<CategoryDialogResult>  ShowCategoryListDialogAsync();

        CategoryDialogResult ShowCategoryListDialog();
    }
}
