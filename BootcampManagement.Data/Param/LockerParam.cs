using BootcampManagement.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampManagement.Data.Param
{
    public class LockerParam
    {
        public string Id { get; set; }
        public string LockerNumber { get; set; }

        public LockerParam() { }

        public LockerParam(Locker locker)
        {
            locker.LockerNumber = this.LockerNumber;
            locker.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public void Update(Locker locker)
        {
            locker.Id = this.Id;
            locker.LockerNumber = this.LockerNumber;
            locker.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public void Delete(Locker locker)
        {
            locker.IsDelete = true;
            locker.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
