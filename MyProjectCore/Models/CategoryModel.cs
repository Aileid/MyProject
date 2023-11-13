using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MyProject.Core.Models
{
    public class CategoryModel : BaseViewModel, IDataErrorInfo, INotifyPropertyChanged
    {
        static uint? increment = 1;
        string? name;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint? IDcategory { get; set; } = increment++;

        /// <summary>
        /// Возвращает или задает значения Name
        /// </summary>
        public string Name
        {
            get => name ?? "NoneName";
            // Ссылка получает указатель на поле и может быть обновлено без ссылки на этот экземпляр класса
            set => RaisePropertyChanged(ref name, value);
        }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Name":
                        if (Name == null || Name.Trim() == "")
                        {
                            error = "Пустая строка";
                        }
                        break;

                }
                return error;
            }
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
    }
}
