using IntegrationClassLib.Equipment.Repository.IRepository;
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

    }
}
