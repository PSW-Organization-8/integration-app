using IntegrationClassLib.Equipment.Repository.IRepository;
using IntegrationClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Equipment.Service
{
    public class EquipmentService
    {
        private readonly IEquipmentRepository equipmentRepository;


        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            this.equipmentRepository = equipmentRepository;

        }

        public List<IntegrationClassLib.SharedModel.Equipment> GetAllEquipments()
        {
            return equipmentRepository.GetAll();
        }

        public void CreateAllEquipments(List<IntegrationClassLib.SharedModel.Equipment> allNewEquipments)
        {
            foreach (IntegrationClassLib.SharedModel.Equipment newEquipments in allNewEquipments)
            {
                CreateEquipments(newEquipments);
            }
        }

        public IntegrationClassLib.SharedModel.Equipment CreateEquipments(IntegrationClassLib.SharedModel.Equipment newEquipments)
        {
            return equipmentRepository.Create(newEquipments);
        }

        public IntegrationClassLib.SharedModel.Equipment Get(long id) 
        {
            return equipmentRepository.Get(id);
        }


        public SharedModel.Equipment GetEquipmentByNameAndRoom(string name, Room room)
        {
            List<IntegrationClassLib.SharedModel.Equipment> allEquipment = GetAllEquipments();
            foreach (IntegrationClassLib.SharedModel.Equipment e in allEquipment)
            {
                if (e.Name == name && e.Room.ID == room.ID)
                    return e;
            }

            return null;
        }

        public SharedModel.Equipment GetByID(int equipmentID)
        {
            List<IntegrationClassLib.SharedModel.Equipment> allEquipment = GetAllEquipments();
            foreach (IntegrationClassLib.SharedModel.Equipment e in allEquipment)
            {
                if (e.ID == equipmentID)
                    return e;
            }

            return null;
        }

        public bool MoveEquipment(SharedModel.Equipment equipment, Room startRoom, Room destinationRoom, double amount)
        {
            if (equipment.Amount < amount)
                return false;

            SharedModel.Equipment fromEquipment = equipmentRepository.GetByIdAndRoomId(equipment.ID, startRoom.ID);
            SharedModel.Equipment toEquipment = equipmentRepository.GetByIdAndRoomId(equipment.ID, destinationRoom.ID);

            if (fromEquipment == null) {
                return false;
            }

            if (toEquipment == null)
            {
                fromEquipment.Amount -= amount;
                equipmentRepository.Update(fromEquipment);

                toEquipment = new SharedModel.Equipment();
                toEquipment.Name = equipment.Name;
                toEquipment.Room = equipment.Room;
                toEquipment.Amount = amount;
                equipmentRepository.Create(toEquipment);
                
            }
            else 
            {
                fromEquipment.Amount -= amount;
                toEquipment.Amount += amount;
                equipmentRepository.Update(fromEquipment);
                equipmentRepository.Update(toEquipment);
            }


            return true;
        }

        public List<IntegrationClassLib.SharedModel.Equipment> GetAllInRoom(Room room)
        {
            List<IntegrationClassLib.SharedModel.Equipment> foundEquipments = new List<SharedModel.Equipment>();

            foreach (IntegrationClassLib.SharedModel.Equipment e in equipmentRepository.GetAll())
            {
                if (e.Room == room)
                    foundEquipments.Add(e);
            }

            return foundEquipments;
        }

        public long GetNextID()
        {
            List<IntegrationClassLib.SharedModel.Equipment> allEquipment = GetAllEquipments();
            long max = 0;
            foreach (IntegrationClassLib.SharedModel.Equipment e in allEquipment)
            {
                if (e.ID > max)
                    max = e.ID;
            }
            return max + 1;
        }

        public List<IntegrationClassLib.SharedModel.Equipment> Search(string str)
        {
            List<IntegrationClassLib.SharedModel.Equipment> foundEquipment = new List<IntegrationClassLib.SharedModel.Equipment>();

            foreach (IntegrationClassLib.SharedModel.Equipment e in GetAllEquipments())
            {
                if (e.Name.Contains(str))
                    foundEquipment.Add(e);

            }

            return foundEquipment;
        }

    }
}
