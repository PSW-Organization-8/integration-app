using IntegrationClassLib.Equipment.Repository;
using IntegrationClassLib.Equipment.Repository.IRepository;
using IntegrationClassLib.Equipment.Service;
using IntegrationClassLib.SharedModel;
using System;
using System.Collections.Generic;
using Xunit;
using Shouldly;
using Moq;

namespace ManagerTests
{
    public class EquipmentSearchTests
    {
        private IEquipmentRepository equipmentRepository;

        [Fact]
        public void Finds_all_equipment()
        {
            EquipmentService service = new EquipmentService(CreateEquipmentStubRepository());

            List<Equipment> foundEquipment = service.GetAllEquipments();

            foundEquipment.Count.ShouldBe(2);
        }

        [Fact]
        public void Move_equipment_half_amount_to_not_empty_room()
        {
            EquipmentService equipmentService = new EquipmentService(CreateEquipmentStubRepository());
            RoomService roomService = new RoomService(CreateRoomStubRepository());

            int equipmentToMoveID = 1;
            int roomToMoveInID = 2;
            double amountToMove = 4;
            double fromAmountBefore = equipmentService.GetByID(equipmentToMoveID).Amount;
            double toAmountBefore = 0;

            if (equipmentService.GetEquipmentByNameAndRoom(equipmentService.GetByID(equipmentToMoveID).Name, roomService.GetByID(roomToMoveInID)) != null)
                toAmountBefore = equipmentService.GetEquipmentByNameAndRoom(equipmentService.GetByID(equipmentToMoveID).Name, roomService.GetByID(roomToMoveInID)).Amount;

            equipmentService.MoveEquipment(equipmentService.GetByID(equipmentToMoveID), roomService.GetByID(roomToMoveInID), amountToMove);

            equipmentService.GetByID(equipmentToMoveID).Amount.ShouldBe(fromAmountBefore - amountToMove);
            equipmentService.GetEquipmentByNameAndRoom(equipmentService.GetByID(equipmentToMoveID).Name, roomService.GetByID(roomToMoveInID)).Amount.ShouldBe(toAmountBefore + amountToMove);

        }

        [Fact]
        public void Move_equipment_full_amount_to_not_empty_room()
        {
            EquipmentService equipmentService = new EquipmentService(CreateEquipmentStubRepository());
            RoomService roomService = new RoomService(CreateRoomStubRepository());

            int equipmentToMoveID = 1;
            string equipmentName = equipmentService.GetByID(equipmentToMoveID).Name;
            int roomToMoveInID = 2;
            double amountToMove = 14;
            double fromAmountBefore = equipmentService.GetByID(equipmentToMoveID).Amount;
            double toAmountBefore = 0;

            if (equipmentService.GetEquipmentByNameAndRoom(equipmentService.GetByID(equipmentToMoveID).Name, roomService.GetByID(roomToMoveInID)) != null)
                toAmountBefore = equipmentService.GetEquipmentByNameAndRoom(equipmentService.GetByID(equipmentToMoveID).Name, roomService.GetByID(roomToMoveInID)).Amount;

            equipmentService.MoveEquipment(equipmentService.GetByID(equipmentToMoveID), roomService.GetByID(roomToMoveInID), amountToMove);

            equipmentService.GetByID(equipmentToMoveID).ShouldBeNull();
            equipmentService.GetEquipmentByNameAndRoom(equipmentName, roomService.GetByID(roomToMoveInID)).Amount.ShouldBe(toAmountBefore + amountToMove);
        }


        [Fact]
        public void Move_equipment_half_amount_to_empty_room()
        {
            EquipmentService equipmentService = new EquipmentService(CreateEquipmentStubRepository());
            RoomService roomService = new RoomService(CreateRoomStubRepository());

            int equipmentToMoveID = 1;
            int roomToMoveInID = 3;
            double amountToMove = 4;
            double fromAmountBefore = equipmentService.GetByID(equipmentToMoveID).Amount;
            double toAmountBefore = 0;

            if (equipmentService.GetEquipmentByNameAndRoom(equipmentService.GetByID(equipmentToMoveID).Name, roomService.GetByID(roomToMoveInID)) != null)
                toAmountBefore = equipmentService.GetEquipmentByNameAndRoom(equipmentService.GetByID(equipmentToMoveID).Name, roomService.GetByID(roomToMoveInID)).Amount;

            equipmentService.MoveEquipment(equipmentService.GetByID(equipmentToMoveID), roomService.GetByID(roomToMoveInID), amountToMove);

            equipmentService.GetByID(equipmentToMoveID).Amount.ShouldBe(fromAmountBefore - amountToMove);
            equipmentService.GetEquipmentByNameAndRoom(equipmentService.GetByID(equipmentToMoveID).Name, roomService.GetByID(roomToMoveInID)).Amount.ShouldBe(toAmountBefore + amountToMove);

        }


        [Fact]
        public void Move_equipment_full_amount_to_empty_room()
        {
            EquipmentService equipmentService = new EquipmentService(CreateEquipmentStubRepository());
            RoomService roomService = new RoomService(CreateRoomStubRepository());

            int equipmentToMoveID = 1;
            string equipmentName = equipmentService.GetByID(equipmentToMoveID).Name;
            int roomToMoveInID = 3;
            double amountToMove = 14;
            double fromAmountBefore = equipmentService.GetByID(equipmentToMoveID).Amount;
            double toAmountBefore = 0;

            if (equipmentService.GetEquipmentByNameAndRoom(equipmentService.GetByID(equipmentToMoveID).Name, roomService.GetByID(roomToMoveInID)) != null)
                toAmountBefore = equipmentService.GetEquipmentByNameAndRoom(equipmentService.GetByID(equipmentToMoveID).Name, roomService.GetByID(roomToMoveInID)).Amount;

            equipmentService.MoveEquipment(equipmentService.GetByID(equipmentToMoveID), roomService.GetByID(roomToMoveInID), amountToMove);

            equipmentService.GetByID(equipmentToMoveID).ShouldBeNull();
            equipmentService.GetEquipmentByNameAndRoom(equipmentName, roomService.GetByID(roomToMoveInID)).Amount.ShouldBe(toAmountBefore + amountToMove);

        }

        private static IRoomRepository CreateRoomStubRepository()
        {
            var stubRepository = new Mock<IRoomRepository>();
            List<Room> roomList = new List<Room>();

            Building building = new Building(1, "Prva zgrada");
            Floor floor = new Floor(1, "Prvi sprat", building);

            Room room1 = new Room(1, "Prva soba", floor);
            Room room2 = new Room(2, "Druga soba", floor);
            Room room3 = new Room(3, "Treca soba", floor);
            roomList.Add(room1);
            roomList.Add(room2);
            roomList.Add(room3);
            stubRepository.Setup(m => m.GetAll()).Returns(roomList);

            return stubRepository.Object;
        }

        private static IEquipmentRepository CreateEquipmentStubRepository()
        {
            RoomService roomService = new RoomService(CreateRoomStubRepository());
            List<Room> rooms = roomService.GetAllRooms();

            var stubEquipmentRepository = new Mock<IEquipmentRepository>();
            List<Equipment> equpmentList = new List<Equipment>();


            Equipment equipment1 = new Equipment(1, "Prva oprema", rooms[0], 14);
            Equipment equipment2 = new Equipment(2, "Druga oprema", rooms[1], 9);
            Equipment equipment3 = new Equipment(3, "Treca oprema", rooms[1], 17);
            equpmentList.Add(equipment1);
            equpmentList.Add(equipment2);
            stubEquipmentRepository.Setup(m => m.GetAll()).Returns(equpmentList);

            return stubEquipmentRepository.Object;

        }

    }
}
