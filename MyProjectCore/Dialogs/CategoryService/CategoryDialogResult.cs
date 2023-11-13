using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Dialogs.CategoryService
{
    public class CategoryDialogResult
    {
        public bool IsSuccess { get; set; }

        public uint? IDcategory { get; set; }
        public string Name { get; set; }
    }
}
