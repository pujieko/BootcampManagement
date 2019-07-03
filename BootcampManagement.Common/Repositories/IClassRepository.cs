using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampManagement.Common.Repositories
{
    public interface IClassRepository
    {
        List<Class> Get();
        Class Get(string id);
        bool Insert(ClassParam classParam);
        bool Update(string id, ClassParam classParam);
        bool Delete(string id);
    }
}
