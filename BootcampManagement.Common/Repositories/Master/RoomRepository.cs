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
    public class RoomRepository : IRoomRepository
    {
        static MyContext myContext = new MyContext();
        Room room = new Room();
        SaveChange saveChange = new SaveChange(myContext);

        public bool Delete(string id)
        {
            var delete = Get(id);
            delete.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            delete.IsDelete = true;
            return saveChange.save();
        }

        public List<Room> Get()
        {
            var get = myContext.Rooms.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Room Get(string id)
        {
            var get = myContext.Rooms.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }

        public bool Insert(RoomParam roomParam)
        {
            room.Id = roomParam.Id;
            room.Name = roomParam.Name;
            room.CreateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.Rooms.Add(room);
            return saveChange.save();
        }

        public bool Update(string id, RoomParam roomParam)
        {
            var put = Get(id);
            put.Name = roomParam.Name;
            put.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            return saveChange.save();
        }
    }
}
