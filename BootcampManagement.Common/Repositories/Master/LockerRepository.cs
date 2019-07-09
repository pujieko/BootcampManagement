using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;

namespace BootcampManagement.Common.Repositories.Master
{
    public class LockerRepository : ILockerRepository
    {
        static MyContext myContext = new MyContext();
        Locker locker = new Locker();

        bool status = false;

        public bool Delete(string id)
        {
            var get = Get(id);
            get.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            get.IsDelete = true;
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Locker> Get()
        {
            var get = myContext.Lockers.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Locker Get(string id)
        {
            var get = myContext.Lockers.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }

        public bool Insert(LockerParam lockerParam)
        {
            locker.Id = lockerParam.LockerNumber;
            locker.LockerNumber = lockerParam.LockerNumber;
            locker.CreateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.Lockers.Add(locker);
            try
            {
                var result = myContext.SaveChanges();
                if (result > 0)
                {
                    status = true;
                }
            }
            catch (DbEntityValidationException e)
            {
                Console.Write(e.EntityValidationErrors);
            }
            

            return status;
        }

        public bool Update(string id, LockerParam lockerParam)
        {
            var get = Get(id);
            get.LockerNumber = lockerParam.LockerNumber;
            get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
