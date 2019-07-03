using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootcampManagement.Client.ViewModels
{
    public class CompanyVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Village_Id { get; set; }
    }
}