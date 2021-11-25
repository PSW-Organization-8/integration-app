using IntegrationClassLib.Equipment.Repository.IRepository;
using IntegrationClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Equipment.Service
{
   public  class RoomService
    {
        private readonly IRoomRepository roomRepository;
        

        public RoomService(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
          
        }

        public List<Room> GetAllRooms()
        {
            return roomRepository.GetAll();
        }

        public void CreateAllRooms(List<Room> allNewRooms)
        {
            foreach (Room newRooms in allNewRooms)
            {
                CreateRooms(newRooms);
            }
        }

        public Room CreateRooms(Room newRooms)
        {
            return roomRepository.Create(newRooms);
        }

    }
}
