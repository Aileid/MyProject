using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyProject.Core.Dialogs.GoodService
{
    public class GoodDialogResult
    {
        public bool IsSuccess { get; set; }

        public uint IDgood { get; set; }
        public ulong UPC { get; set; }
        public string Name { get; set; }
        public uint? Cost{get;set; }
        public DateTime? ProductionDate { get; set; }
        public DateTime? ExpirationDate{get; set; }
        public DateTime? DeliveryDate{get; set; }
        public ushort Count{get; set; }
        public uint? IDcategory{get; set; }
    }
}
