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

        public bool MoveEquipment(SharedModel.Equipment equipment, Room room, double amount)
        {
            if (equipment.Amount < amount)
                return false;

            List<IntegrationClassLib.SharedModel.Equipment> allEquipment = GetAllEquipments();
            foreach (IntegrationClassLib.SharedModel.Equipment e in allEquipment)
            {
                if (e.Name == equipment.Name && e.Room.ID == room.ID)
                {
                    e.Amount += amount;
                    equipmentRepository.Update(e);
                    equipment.Amount -= amount;

                    if (equipment.Amount == 0)
                    {
                        allEquipment.Remove(equipment);
                    }
                    return true;
                }
            }

            allEquipment.Add(new IntegrationClassLib.SharedModel.Equipment(GetNextID(), equipment.Name, room, amount));

            equipment.Amount -= amount;

            if (equipment.Amount == 0)
            {
                allEquipment.Remove(equipment);
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

    }
}
