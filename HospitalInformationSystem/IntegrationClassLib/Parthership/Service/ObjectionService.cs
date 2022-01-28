using IntegrationClassLib.Parthership.Model;
using IntegrationClassLib.Parthership.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationClassLib.Parthership.Repository.Interface;

namespace IntegrationClassLib.Parthership.Service
{

    public class ObjectionService
    {


        private readonly IObjectionRepository objectionRepository;

        public ObjectionService(IObjectionRepository objectionRepository) {
            this.objectionRepository = objectionRepository;
        }

        public Objection Add(Objection objection)
        {
            return objectionRepository.Create(objection);
        }

        public List<Objection> GetAll()
        {
            return objectionRepository.GetAll();
        }

        public Objection GetObjection(long id) {
            return objectionRepository.Get(id);
        }

    }
}
