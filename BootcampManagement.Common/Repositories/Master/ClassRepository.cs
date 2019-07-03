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
    public class ClassRepository : IClassRepository
    {
        static MyContext myContext = new MyContext();
        Class classes = new Class();
        SaveChange saveChange = new SaveChange(myContext);

        public bool Delete(string id)
        {
            var delete = Get(id);
            delete.IsDelete = true;
            delete.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            return saveChange.save();
        }

        public List<Class> Get()
        {
            var get = myContext.Classes.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Class Get(string id)
        {
            var get = myContext.Classes.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }

        public bool Insert(ClassParam classParam)
        {
            classes.Name = classParam.Name;
            classes.CreateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.Classes.Add(classes);
            return saveChange.save();
        }

        public bool Update(string id, ClassParam classParam)
        {
            var get = Get(id);
            get.Name = classParam.Name;
            get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            return saveChange.save();
        }
    }
}
