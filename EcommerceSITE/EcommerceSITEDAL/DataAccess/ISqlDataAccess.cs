﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSITEDAL.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> GetData<T, P>(string spName, P parameters, string connectionId = "conn");
        Task SaveData<T>(string spName, T parameters, string connectionId = "conn");

    }
}
