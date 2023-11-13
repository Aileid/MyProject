using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Models
{
    public class GoodModel: BaseViewModel, IDataErrorInfo, INotifyPropertyChanged
    {
        static uint increment = 1;

        ulong upc;
        string name;
        uint? cost;
        DateTime? productionDate;
        DateTime? expirationDate;
        DateTime? deliveryDate;
        ushort count;
        uint? iDcategory;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint IDgood { get; set; } = increment++;

        public ulong UPC
        {
            get => upc;

            set => RaisePropertyChanged(ref upc, value);
        }

        public string Name
        {
            get => name ?? "NoneName";

            set => RaisePropertyChanged(ref name, value);
        }

        public uint? Cost
        {
            get => cost;

            set => RaisePropertyChanged(ref cost, value);
        }

        public DateTime? ProductionDate
        {
            get => productionDate;

            set => RaisePropertyChanged(ref productionDate, value);
        }

        public DateTime? ExpirationDate
        {
            get => expirationDate;

            set => RaisePropertyChanged(ref expirationDate, value);
        }

        public DateTime? DeliveryDate
        {
            get => deliveryDate;

            set => RaisePropertyChanged(ref deliveryDate, value);
        }

        public ushort Count
        {
            get => count;

            set => RaisePropertyChanged(ref count, value);
        }

        public uint? IDcategory
        {
            get => iDcategory;

            set => RaisePropertyChanged(ref iDcategory, value);
        }

        [ForeignKey("IDcategory")]
        public CategoryModel? Category { get; set; }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Name":
                        if (Name != null && Name.Trim() == "")
                        {
                            error = "Пустая строка";
                        }
                        break;
                    case "UPC":
                        if (UPC == 0 || UPC.ToString().Length<6)
                        {
                            error = "Код товара должен состоять из 6 цифр";
                        }
                        break;
                    case "Cost":
                        if (Cost == 0)
                        {
                            error = "Товар не может быть без цены";
                        }
                        break;
                    case "Count":
                        if (Count==0)
                        {
                            error = "Количество не может быть нулевым";
                        }
                        break;
                    case "DeliveryDate":
                        if (false)
                        {
                            error = "неправильная дата";
                        }
                        break;
                    case "ExpirationDate":

                        break;
                    case "ProductionDate":

                        break;
                    case "IDcategory":

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
