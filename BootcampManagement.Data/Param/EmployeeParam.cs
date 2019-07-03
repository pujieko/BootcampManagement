using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampManagement.Data.Param
{
    public class EmployeeParam
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int PlaceOfBirth_Id { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsSite { get; set; }
        public string SecretQuestion { get; set; }
        public string SecretAnswer { get; set; }
        public int HiringLocation_Id { get; set; }
        public int Religion_Id { get; set; }
        public int Village_Id { get; set; }
    }
}
