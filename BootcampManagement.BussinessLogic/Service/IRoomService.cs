﻿using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampManagement.BussinessLogic.Service
{
    public interface IRoomService
    {
        List<Room> Get();
        Room Get(string id);
        bool Insert(RoomParam roomParam);
        bool Update(string id, RoomParam roomParam);
        bool Delete(string id);
    }
}
