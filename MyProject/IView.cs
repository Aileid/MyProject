﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public interface IView
    {
        /// <summary>
        /// Закрытие представления с возвратом результата
        /// </summary>
        void CloseDialog(bool result);
    }
}
