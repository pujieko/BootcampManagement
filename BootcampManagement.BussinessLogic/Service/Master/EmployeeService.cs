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
    public class EmployeeService : IEmployeeService
    {
        bool status = false;

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public EmployeeService() { }

        public bool Delete(string id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = Get(id);
            return _employeeRepository.Delete(get.Id);
        }

        public List<Employee> Get()
        {
            var get = _employeeRepository.Get();
            if (get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public Employee Get(string id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = _employeeRepository.Get(id);
            if (get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public bool Insert(EmployeeParam employeeParam)
        {
            if (employeeParam == null)
            {
                throw new NullReferenceException();
            }
            else if (employeeParam.FirstName == " " || employeeParam.FirstName == "")
            {
                throw new NullReferenceException();
            }
            else if (employeeParam.LastName == " " || employeeParam.LastName == "")
            {
                throw new NullReferenceException();
            }
            else if (employeeParam.Address == " " || employeeParam.Address == "")
            {
                throw new NullReferenceException();
            }
            else if (employeeParam.Phone == " " || employeeParam.Phone == "")
            {
                throw new NullReferenceException();
            }
            else if (employeeParam.Email == " " || employeeParam.Email == "")
            {
                throw new NullReferenceException();
            }
            else if (employeeParam.Username == " " || employeeParam.Username == "")
            {
                throw new NullReferenceException();
            }
            else if (employeeParam.Password == " " || employeeParam.Password == "")
            {
                throw new NullReferenceException();
            }
            else if (employeeParam.SecretQuestion == " " || employeeParam.SecretQuestion == "")
            {
                throw new NullReferenceException();
            }
            else if (employeeParam.SecretAnswer == " " || employeeParam.SecretAnswer == "")
            {
                throw new NullReferenceException();
            }
            else if (employeeParam.HiringLocation_Id == 0)
            {
                throw new NullReferenceException();
            }
            else if (employeeParam.Religion_Id == 0)
            {
                throw new NullReferenceException();
            }
            else if (employeeParam.Village_Id == 0)
            {
                throw new NullReferenceException();
            }
            else
            {
                status = _employeeRepository.Insert(employeeParam);
            }
            return status;
        }

        public bool Update(string id, EmployeeParam employeeParam)
        {
            if (employeeParam == null)
            {
                throw new NullReferenceException();
            }
            else if (employeeParam.FirstName == " " || employeeParam.FirstName == "")
            {
                throw new NullReferenceException();
            }
            else if (employeeParam.LastName == " " || employeeParam.LastName == "")
            {
                throw new NullReferenceException();
            }
            else if (employeeParam.Address == " " || employeeParam.Address == "")
            {
                throw new NullReferenceException();
            }
            else if (employeeParam.Phone == " " || employeeParam.Phone == "")
            {
                throw new NullReferenceException();
            }
            else if (employeeParam.Email == " " || employeeParam.Email == "")
            {
                throw new NullReferenceException();
            }
            else if (employeeParam.Username == " " || employeeParam.Username == "")
            {
                throw new NullReferenceException();
            }
            else if (employeeParam.Password == " " || employeeParam.Password == "")
            {
                throw new NullReferenceException();
            }
            else if (employeeParam.SecretQuestion == " " || employeeParam.SecretQuestion == "")
            {
                throw new NullReferenceException();
            }
            else if (employeeParam.SecretAnswer == " " || employeeParam.SecretAnswer == "")
            {
                throw new NullReferenceException();
            }
            else if (employeeParam.HiringLocation_Id == 0)
            {
                throw new NullReferenceException();
            }
            else if (employeeParam.Religion_Id == 0)
            {
                throw new NullReferenceException();
            }
            else if (employeeParam.Village_Id == 0)
            {
                throw new NullReferenceException();
            }
            else
            {
                status = _employeeRepository.Update(id, employeeParam);
            }
            return status;
        }
    }
}
