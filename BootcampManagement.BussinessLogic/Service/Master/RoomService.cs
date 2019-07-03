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
    public class RoomService : IRoomService
    {
        bool status = false;

        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public RoomService() { }

        public bool Delete(string id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = Get(id);
            return _roomRepository.Delete(get.Id);
        }

        public List<Room> Get()
        {
            var get = _roomRepository.Get();
            if (get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public Room Get(string id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = _roomRepository.Get(id);
            if (get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public bool Insert(RoomParam roomParam)
        {
            if (roomParam == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                status = _roomRepository.Insert(roomParam);
            }
            return status;
        }

        public bool Update(string id, RoomParam roomParam)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = Get(id);
            if (roomParam == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                status = _roomRepository.Update(id, roomParam);
            }
            return status;
        }
    }
}
