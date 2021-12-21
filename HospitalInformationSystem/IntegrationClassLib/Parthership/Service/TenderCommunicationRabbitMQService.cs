using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationClassLib.Parthership.Model.Tendering;
using Newtonsoft.Json;

namespace IntegrationClassLib.Parthership.Service
{
    public class TenderCommunicationRabbitMQService
    {
        private readonly string _hostName = Environment.GetEnvironmentVariable("RabbitHostName") ?? "localhost";

        public void SendTenderToRegistratedPharmacies(Tender newTender)
        {
            var factory = new ConnectionFactory() { HostName = _hostName };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "newTendersExchange", type: ExchangeType.Fanout);

                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(newTender));
                channel.BasicPublish(exchange: "newTendersExchange",
                    routingKey: "",
                    basicProperties: null,
                    body: body);
            }
        }
    }
}
