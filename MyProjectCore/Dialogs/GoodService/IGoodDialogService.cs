using MyProject.Core.Dialogs.CategoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Dialogs.GoodService
{
    public interface IGoodDialogService
    {
        Task<GoodDialogResult> ShowGoodDialogAsync(object? p=null);

        GoodDialogResult ShowGoodDialog(object? p=null);

        Task<GoodDialogResult> ShowGoodListDialogAsync();

        GoodDialogResult ShowGoodListDialog();
    }
}
