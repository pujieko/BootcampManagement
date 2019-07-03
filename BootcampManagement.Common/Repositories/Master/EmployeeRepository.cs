using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootcampManagement.Data;
using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;

namespace BootcampManagement.Common.Repositories.Master
{
    public class EmployeeRepository : IEmployeeRepository
    {
        static MyContext myContext = new MyContext();
        Employee employee = new Employee();
        SaveChange saveChange = new SaveChange(myContext);

        public bool Delete(string id)
        {
            var delete = Get(id);
            delete.IsDelete = true;
            delete.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            return saveChange.save();
        }

        public List<Employee> Get()
        {
            var get = myContext.Employees.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Employee Get(string id)
        {
            var get = myContext.Employees.SingleOrDefault(x => x.IsDelete == false);
            return get;
        }

        public bool Insert(EmployeeParam employeeParam)
        {
            employee.Id = employeeParam.Id;
            employee.FirstName = employeeParam.FirstName;
            employee.LastName = employeeParam.LastName;
            employee.DateOfBirth = employeeParam.DateOfBirth;
            employee.PlaceOfBirth = employeeParam.PlaceOfBirth_Id;
            employee.Gender = employeeParam.Gender;
            employee.Address = employeeParam.Address;
            employee.Phone = employeeParam.Phone;
            employee.Email = employeeParam.Email;
            employee.Username = employeeParam.Username;
            employee.Password = employeeParam.Password;
            employee.IsSite = employeeParam.IsSite;
            employee.SecretQuestion = employeeParam.SecretQuestion;
            employee.SecretAnswer = employeeParam.SecretAnswer;
            employee.HiringLocation = employeeParam.HiringLocation_Id;
            employee.Religion_Id = employeeParam.Religion_Id;
            employee.Village_Id = employeeParam.Village_Id;
            myContext.Employees.Add(employee);
            return saveChange.save();
        }

        public bool Update(string id, EmployeeParam employeeParam)
        {
            employee.FirstName = employeeParam.FirstName;
            employee.LastName = employeeParam.LastName;
            employee.DateOfBirth = employeeParam.DateOfBirth;
            employee.PlaceOfBirth = employeeParam.PlaceOfBirth_Id;
            employee.Gender = employeeParam.Gender;
            employee.Address = employeeParam.Address;
            employee.Phone = employeeParam.Phone;
            employee.Email = employeeParam.Email;
            employee.Username = employeeParam.Username;
            employee.Password = employeeParam.Password;
            employee.IsSite = employeeParam.IsSite;
            employee.SecretQuestion = employeeParam.SecretQuestion;
            employee.SecretAnswer = employeeParam.SecretAnswer;
            employee.HiringLocation = employeeParam.HiringLocation_Id;
            employee.Religion_Id = employeeParam.Religion_Id;
            employee.Village_Id = employeeParam.Village_Id;
            return saveChange.save();
        }
    }
}
