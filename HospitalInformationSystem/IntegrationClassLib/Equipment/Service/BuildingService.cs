using IntegrationClassLib.Equipment.Repository.IRepository;
using IntegrationClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Equipment.Service
{
    public class BuildingService
    {
        private readonly IBuildingRepository buildingRepository;


        public BuildingService(IBuildingRepository buildingRepository)
        {
            this.buildingRepository = buildingRepository;

        }

        public List<Building> GetAllBuildings()
        {
            return buildingRepository.GetAll();
        }

        public void CreateAllBuildings(List<Building> allNewBuildings)
        {
            foreach (Building newBuildings in allNewBuildings)
            {
                CreateBuildings(newBuildings);
            }
        }

        public Building CreateBuildings(Building newBuildings)
        {
            return buildingRepository.Create(newBuildings);
        }

    }
}
