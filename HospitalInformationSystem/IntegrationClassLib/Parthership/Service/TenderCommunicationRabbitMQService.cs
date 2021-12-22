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
        private readonly string _hospitalName = "Bolnica1";

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

        public List<string> GetReceivedTenderOffers()
        {
            List<string> receivedTenderOffers = new List<string>();
            var factory = new ConnectionFactory() { HostName = _hostName };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "tenderOfferExchange", type: ExchangeType.Fanout);

                string newTenderOffer = null;
                do
                {
                    var basicGetResult = channel.BasicGet(_hospitalName + "TenderOffer", true);     // prvi parametar je od kojeg reda se uzima poruka
                    if (basicGetResult == null)
                    {
                        newTenderOffer = null;
                        continue;
                    }
                    var body = basicGetResult.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    string arrivedTenderOffer = message; //JsonConvert.DeserializeObject<News>(message);
                    /*
                    newTenderOffer = new News()
                    {
                        IdFromPharmacy = arrivedNews.Id,
                        Title = arrivedNews.Title,
                        Text = arrivedNews.Text,
                        DurationStart = arrivedNews.DurationStart,
                        DurationEnd = arrivedNews.DurationEnd,
                        Posted = false
                    };
                    */
                    receivedTenderOffers.Add(newTenderOffer);
                } while (newTenderOffer != null);
            }

            return receivedTenderOffers;
        }
    }
}
