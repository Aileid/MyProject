using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core
{
    static class DataBaseInstance
    {
        static ApplicationContext databaseinstence;
        public static ApplicationContext bd
        {
            get
            {
                if (databaseinstence == null)
                {
                    databaseinstence = new ApplicationContext();
                }
                return databaseinstence;
            } 
        }
    }
}
