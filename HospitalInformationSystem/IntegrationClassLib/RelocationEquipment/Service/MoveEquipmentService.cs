using IntegrationClassLib.Equipment.Repository;
using IntegrationClassLib.Equipment.Repository.IRepository;
using IntegrationClassLib.Equipment.Service;
using IntegrationClassLib.RelocationEquipment.Repository.IRepository;
using IntegrationClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.RelocationEquipment.Service
{
    public class MoveEquipmentService
    {
        private readonly IMoveEquipmentRepository moveEquipmentRepository;
        private readonly IEquipmentRepository equipmentRepository;
        private readonly EquipmentService equipmentService;

        public MoveEquipmentService(IMoveEquipmentRepository moveEquipmentRepository, IEquipmentRepository equipmentRepository, EquipmentService equipmentService)
        {
            this.moveEquipmentRepository = moveEquipmentRepository;
            this.equipmentRepository = equipmentRepository;
            this.equipmentService = equipmentService;
        }

        public List<IntegrationClassLib.SharedModel.MoveEquipment> GetAllEquipments()
        {
            return moveEquipmentRepository.GetAll();
        }

        public void CreateAllEquipments(List<IntegrationClassLib.SharedModel.MoveEquipment> allNewEquipments)
        {
            foreach (IntegrationClassLib.SharedModel.MoveEquipment newEquipments in allNewEquipments)
            {
                CreateEquipments(newEquipments);
            }
        }

        public IntegrationClassLib.SharedModel.MoveEquipment CreateEquipments(IntegrationClassLib.SharedModel.MoveEquipment newEquipments)
        {
            return moveEquipmentRepository.Create(newEquipments);
        }

        public IntegrationClassLib.SharedModel.MoveEquipment Get(long id)
        {
            return moveEquipmentRepository.Get(id);
        }

        public bool SubmitRelocation(long id,IntegrationClassLib.SharedModel.Equipment equipment, double amount, Room destination, DateTime time, String durationRel )
        {
           
           if(equipment.Amount < amount)
           {
                return false;
           }

            MoveEquipment me = new MoveEquipment(id, equipment, destination, time, durationRel, amount);
            moveEquipmentRepository.Create(me);
           return equipmentService.MoveEquipment(equipment, destination, amount);

         


        }

    }
}
