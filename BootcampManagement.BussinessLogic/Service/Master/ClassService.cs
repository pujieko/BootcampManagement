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
    public class ClassService : IClassService
    {
        bool status = false;

        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public ClassService() { }

        public bool Delete(string id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = Get(id);
            return _classRepository.Delete(get.Id);
        }

        public List<Class> Get()
        {
            var get = _classRepository.Get();
            if (get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public Class Get(string id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = _classRepository.Get(id);
            if (get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public bool Insert(ClassParam classParam)
        {
            if (classParam == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                status = _classRepository.Insert(classParam);
            }
            return status;
        }

        public bool Update(string id, ClassParam classParam)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = Get(id);
            if (classParam == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                status = _classRepository.Update(id, classParam);
            }
            return status;
        }
    }
}
