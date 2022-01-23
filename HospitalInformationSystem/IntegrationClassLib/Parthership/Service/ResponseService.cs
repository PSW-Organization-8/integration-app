using IntegrationClassLib.Parthership.Model;
using IntegrationClassLib.Parthership.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationClassLib.Parthership.Repository.Interface;

namespace IntegrationClassLib.Parthership.Service
{
    public class ResponseService
    {
        private readonly IResponseRepository responseRepository;

        public ResponseService(IResponseRepository responseRepository) {
            this.responseRepository = responseRepository;
        }

        public Response Add(Response response)
        {
            return responseRepository.Create(response);
        }

        public List<Response> GetAll()
        {
            return responseRepository.GetAll();
        }
    }
}
