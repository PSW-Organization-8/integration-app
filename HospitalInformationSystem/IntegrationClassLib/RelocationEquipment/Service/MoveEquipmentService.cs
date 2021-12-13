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
        private readonly IRoomRepository roomRepository;


        public MoveEquipmentService(IMoveEquipmentRepository moveEquipmentRepository, IEquipmentRepository equipmentRepository, EquipmentService equipmentService, IRoomRepository roomRepository)
        {
            this.moveEquipmentRepository = moveEquipmentRepository;
            this.equipmentRepository = equipmentRepository;
            this.equipmentService = equipmentService;
            this.roomRepository = roomRepository;
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

        public bool SubmitRelocation(long idEq,long idRoom, double amount, long destinationRoom, DateTime time, string duration)
        {
            IntegrationClassLib.SharedModel.Equipment equipment = equipmentRepository.Get(idEq);


           if (equipment != null && equipmentRepository.Get(idEq).Amount < amount)
           {
                return false;
           }

            MoveEquipmentDTO meDTO = new MoveEquipmentDTO();
            
           return equipmentService.MoveEquipment(equipmentRepository.Get(idEq), roomRepository.Get(destinationRoom), amount);

         


        }

    }
}
