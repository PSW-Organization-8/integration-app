using IntegrationClassLib.Equipment.Repository.IRepository;
using IntegrationClassLib.Equipment.Service;
using IntegrationClassLib.RoomRenovation.Service;
using IntegrationClassLib.SharedModel;
using ManagerTests.InMemoryRepository;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ManagerTests
{
    public class RoomRenovationTests
    {
        private IRoomRepository roomRepository;
        private RoomRenovationService roomRenovationService;
        private RoomService roomService;
        private readonly ITestOutputHelper _testOutputHelper;

        public RoomRenovationTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Find_rooms_for_merging()
        {
            RoomService roomService = new RoomService(CreateRoomStubRepository());
            RoomRenovationService roomRenovationService = new RoomRenovationService(roomService);

            List<Room> foundRooms = roomRenovationService.FindRoomsAvailableForMerging(7);
            _testOutputHelper.WriteLine(foundRooms[0].ID.ToString());
            _testOutputHelper.WriteLine(foundRooms[1].ID.ToString());
            _testOutputHelper.WriteLine(foundRooms[2].ID.ToString());
            foundRooms.Count.ShouldBe(3);

            foundRooms = foundRooms.OrderBy(r => r.ID).ToList();

            foundRooms[0].ID.ShouldBe(4);
            foundRooms[1].ID.ShouldBe(6);
            foundRooms[2].ID.ShouldBe(8);
        }


        [Fact]
        public void Split_room()
        {
            //RoomService roomService = new RoomService(CreateRoomStubRepository());
            //RoomRenovationService roomRenovationService = new RoomRenovationService(roomService);
            PrepareRoomTestRepository();


            //Room newRoom = new Room(10, "Nova soba", new Floor());
            //newRoom.Graphics = new RoomGraphics() { X = 1, Y = 1, XSpan = 1, YSpan = 1, RowPercent = 20 };
            //roomService.CreateRooms(newRoom);

            List<Room> rooms = roomService.GetAllRooms();

            roomRenovationService.SplitRoom(roomService.GetByID(7), "Nova soba");

            //List<Room> rooms = roomService.GetAllRooms();

            roomService.GetAllRooms().Count.ShouldBe(10);
            roomService.GetByID(7).Graphics.Y.ShouldBe(2);
            roomService.GetByID(10).Graphics.Y.ShouldBe(1);
            roomService.GetByID(8).Graphics.Y.ShouldBe(3);
            roomService.GetByID(9).Graphics.Y.ShouldBe(4);
            //roomService.GetByID(7).Graphics.RowPercent.ShouldBe(12.5);
            //roomService.GetByID(10).Graphics.RowPercent.ShouldBe(12.5);
            //roomService.GetByID(8).Graphics.RowPercent.ShouldBe(25);
            //roomService.GetByID(9).Graphics.RowPercent.ShouldBe(25);
            Assert.Equal(12.5, roomService.GetByID(7).Graphics.RowPercent);
            Assert.Equal(12.5, roomService.GetByID(10).Graphics.RowPercent);
            Assert.Equal(25, roomService.GetByID(8).Graphics.RowPercent);
            Assert.Equal(25, roomService.GetByID(9).Graphics.RowPercent);
        }

        [Fact]
        public void Merge_rooms()
        {
            //RoomService roomService = new RoomService(CreateRoomStubRepository());
            //RoomRenovationService roomRenovationService = new RoomRenovationService(roomService);
            PrepareRoomTestRepository();
            //List<Room> rooms = roomService.GetAllRooms();

            roomRenovationService.MergeRooms(roomService.GetByID(7), roomService.GetByID(6), "Nova soba");

            roomService.GetAllRooms().Count.ShouldBe(8);
            roomService.GetByID(10).Graphics.X.ShouldBe(2);
            roomService.GetByID(10).Graphics.Y.ShouldBe(1);
            roomService.GetByID(10).Graphics.RowPercent.ShouldBe(50);

        }

        private static IRoomRepository CreateRoomStubRepository()
        {
            var stubRepository = new Mock<IRoomRepository>();
            List<Room> roomList = new List<Room>();

            Building building = new Building(1, "Prva zgrada");
            Floor floor = new Floor(1, "Prvi sprat", building);

            Room room1 = new Room(1, "Prva soba", floor);
            room1.Graphics = new RoomGraphics() { X = 0, Y = 0, XSpan = 1, YSpan = 1, RowPercent = 33 };
            Room room2 = new Room(2, "Druga soba", floor);
            room2.Graphics = new RoomGraphics() { X = 0, Y = 1, XSpan = 1, YSpan = 1, RowPercent = 33 };
            Room room3 = new Room(3, "Treca soba", floor);
            room3.Graphics = new RoomGraphics() { X = 0, Y = 2, XSpan = 1, YSpan = 1, RowPercent = 33 };
            Room room4 = new Room(4, "Cetvrta soba", floor);
            room4.Graphics = new RoomGraphics() { X = 1, Y = 0, XSpan = 2, YSpan = 1, RowPercent = 50 };
            Room room5 = new Room(5, "Peta soba", floor);
            room5.Graphics = new RoomGraphics() { X = 1, Y = 1, XSpan = 2, YSpan = 1, RowPercent = 50 };
            Room room6 = new Room(6, "Sesta soba", floor);
            room6.Graphics = new RoomGraphics() { X = 2, Y = 0, XSpan = 1, YSpan = 1, RowPercent = 25 };
            Room room7 = new Room(7, "Sedma soba", floor);
            room7.Graphics = new RoomGraphics() { X = 2, Y = 1, XSpan = 1, YSpan = 1, RowPercent = 25 };
            Room room8 = new Room(8, "Osma soba", floor);
            room8.Graphics = new RoomGraphics() { X = 2, Y = 2, XSpan = 1, YSpan = 1, RowPercent = 25 };
            Room room9 = new Room(9, "Deveta soba", floor);
            room9.Graphics = new RoomGraphics() { X = 2, Y = 3, XSpan = 1, YSpan = 1, RowPercent = 25 };



            roomList.Add(room1);
            roomList.Add(room2);
            roomList.Add(room3);
            roomList.Add(room4);
            roomList.Add(room5);
            roomList.Add(room6);
            roomList.Add(room7);
            roomList.Add(room8);
            roomList.Add(room9);
            stubRepository.Setup(m => m.GetAll()).Returns(roomList);

            return stubRepository.Object;
        }

        private void PrepareRoomTestRepository()
        {
            roomRepository = new RoomTestRepository();
            roomService = new RoomService(roomRepository);
            roomRenovationService = new RoomRenovationService(roomService);
        }


    }
}
