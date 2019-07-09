using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootcampManagement.Common.Repositories;
using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;

namespace BootcampManagement.BussinessLogic.Service.Master
{
    public class LockerService : ILockerService
    {
        bool status = false;

        private readonly ILockerRepository _lockerRepository;

        public LockerService(ILockerRepository lockerRepository)
        {
            _lockerRepository = lockerRepository;
        }

        public bool Delete(string id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            return _lockerRepository.Delete(id);
        }

        public List<Locker> Get()
        {
            var get = _lockerRepository.Get();
            if (get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public Locker Get(string id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = _lockerRepository.Get(id);
            if (get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public bool Insert(LockerParam lockerParam)
        {
            if (lockerParam == null)
            {
                return false;
            }
            else if (lockerParam.LockerNumber == " ")
            {
                status = false;
            }
            else
            {
                status = _lockerRepository.Insert(lockerParam);
            }
            return status;
        }

        public bool Update(string id, LockerParam lockerParam)
        {
            if (id == null)
            {
                return false;
            }
            var get = Get(id);
            if (lockerParam == null)
            {
                return false;
            }
            else if (lockerParam.LockerNumber == " ")
            {
                status = false;
            }
            else
            {
                status = _lockerRepository.Update(id, lockerParam);
            }
            return status;
        }
    }
}
