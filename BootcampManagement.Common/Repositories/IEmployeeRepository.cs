﻿using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampManagement.Common.Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> Get();
        Employee Get(string id);
        bool Insert(EmployeeParam employeeParam);
        bool Update(string id, EmployeeParam employeeParam);
        bool Delete(string id);
    }
}
