using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampManagement.BussinessLogic.Service
{
    public interface ILockerService
    {
        List<Locker> Get();
        Locker Get(string id);
        bool Insert(LockerParam lockerParam);
        bool Update(string id, LockerParam lockerParam);
        bool Delete(string id);
    }
}
