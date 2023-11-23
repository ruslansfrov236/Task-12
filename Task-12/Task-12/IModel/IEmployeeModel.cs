﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_12.Customer.BaseEntity;

namespace Task_12.IModel
{
    public interface IEmployeeModel< T> where T : Human
    {
        List<T> GetAll();
        List<T> GetSearch(string search);
        void Create();

    }
}
