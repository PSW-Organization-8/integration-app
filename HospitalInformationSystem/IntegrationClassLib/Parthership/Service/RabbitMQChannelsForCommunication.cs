using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationClassLib.Parthership.Service.Interface;
using IntegrationClassLib.Pharmacy.Repository.PharmacyRepo;
using IntegrationClassLib.Pharmacy.Service;
using RabbitMQ.Client;

namespace IntegrationClassLib.Parthership.Service
{
    public class RabbitMQChannelsForCommunication : IChannelsForCommunication
    {
        private IPharmacyRepository pharmacyRepository;
        private readonly string _hostName = Environment.GetEnvironmentVariable("RabbitHostName") ?? "localhost";

        public RabbitMQChannelsForCommunication(IPharmacyRepository pharmacyRepository)
        {
            this.pharmacyRepository = pharmacyRepository;
        }

        public void CreateChannelsForPharmacy(Pharmacy.Model.Pharmacy pharmacy)
        {
            CreateChannelForSendingTenders(pharmacy);
        }

        public void CreateAllChannels()
        {
            CreateAllChannelsWithAllPharmacies();
        }

        private void CreateAllChannelsWithAllPharmacies()
        {
            foreach (Pharmacy.Model.Pharmacy pharmacy in pharmacyRepository.GetAll())
            {
                CreateChannelsForPharmacy(pharmacy);
            }
        }

        private void CreateChannelForSendingTenders(Pharmacy.Model.Pharmacy pharmacy)
        {
            var factory = new ConnectionFactory() { HostName = _hostName };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "newTendersExchange", type: ExchangeType.Fanout);

                channel.QueueDeclare(queue: pharmacy.Name,
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                channel.QueueBind(queue: pharmacy.Name,
                    exchange: "newTendersExchange",
                    routingKey: "");
            }
        }
    }
}
