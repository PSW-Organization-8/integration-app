using IntegrationClassLib.Equipment.Repository.IRepository;
using IntegrationClassLib.Equipment.Service;
using IntegrationClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.RoomRenovation.Service
{
    public class RoomRenovationService
    {
        private readonly RoomService roomService;


        public RoomRenovationService(RoomService roomService)
        {
            this.roomService = roomService;
        }

        public List<Room> FindRoomsAvailableForMerging(long id)
        {
            Room room = roomService.GetByID(id);

            List<Room> foundRooms = new List<Room>();

            foreach (Room r in roomService.GetAllRooms())
            {
                if (room == r)
                    continue;

                //ako su u istom redu
                if (room.Graphics.X == r.Graphics.X)
                {
                    if (room.Graphics.Y == r.Graphics.Y + 1 || room.Graphics.Y == r.Graphics.Y - 1)
                    {
                        foundRooms.Add(r);
                        continue;
                    }

                }//ako nisu u istom redu
                else
                {
                    (int XStart1, int XEnd1) = GetAbsoluteXSpan(room);
                    (int XStart2, int XEnd2) = GetAbsoluteXSpan(r);

                    if ((XEnd1 >= XStart2) && (XEnd2 >= XStart1) && (room.Graphics.X == r.Graphics.X + 1 || room.Graphics.X == r.Graphics.X - 1))
                    {
                        foundRooms.Add(r);
                        continue;
                    }
                }

            }

            return foundRooms;

        }

        (int Start, int End) GetAbsoluteXSpan(Room room)
        {
            int XStart = 0;

            foreach (Room r in roomService.GetAllRooms())
            {
                if (r.Graphics.X != room.Graphics.X)
                    continue;

                if (r.Graphics.Y < room.Graphics.Y)
                {
                    XStart += r.Graphics.XSpan;
                }

            }

            return (XStart, XStart + room.Graphics.XSpan - 1);
        }

        public void SplitRoom(Room room, string name)
        {
            room.Graphics.RowPercent /= 2;
            roomService.UpdateRoom(room);

            int x = room.Graphics.X;
            int y = room.Graphics.Y;

            foreach (Room r in roomService.GetAllRooms())
            {
                // ako nije isti red ne menjaj nista
                if (r.Graphics.X != x)
                    continue;

                // ako je sa desne strane
                if (r.Graphics.Y >= y)
                {
                    r.Graphics.Y += 1;
                    roomService.UpdateRoom(r);
                }
            }

            Room newRoom = new Room(roomService.GetNextID(), name, room.Floor);
            newRoom.Graphics = new RoomGraphics() { X = x, Y = y, XSpan = 1, YSpan = 1, RowPercent = room.Graphics.RowPercent };
            roomService.CreateRooms(newRoom);
        }

        public void MergeRooms(Room room1, Room room2, string name)
        {
            Room newRoom = new Room(roomService.GetNextID(), name, room1.Floor);
            newRoom.Graphics = new RoomGraphics() { X = room1.Graphics.X, Y = room1.Graphics.Y, XSpan = 1, YSpan = 1, RowPercent = room1.Graphics.RowPercent + room2.Graphics.RowPercent };
            roomService.CreateRooms(newRoom);

            int x = room1.Graphics.X;
            int y = room1.Graphics.Y;

            foreach (Room r in roomService.GetAllRooms())
            {
                // ako nije isti red ne menjaj nista
                if (r.Graphics.X != x)
                    continue;

                // ako je sa desne strane
                if (r.Graphics.Y > y)
                {
                    r.Graphics.Y -= 1;
                    roomService.UpdateRoom(r);
                }
            }

            roomService.Delete(room1);
            roomService.Delete(room2);
        }



    }
}
