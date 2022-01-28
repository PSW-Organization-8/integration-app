using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntegrationClassLib.Tendering.Model;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace IntegrationClassLib.Tendering.Service
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

        public List<PharmacyOffer> GetReceivedTenderOffers()
        {
            List<PharmacyOffer> receivedTenderOffers = new();
            var factory = new ConnectionFactory() { HostName = _hostName };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "tenderOfferExchange", type: ExchangeType.Fanout);

                PharmacyOffer newTenderOffer = null;
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
                    PharmacyOffer arrivedPharmacyOffer = JsonConvert.DeserializeObject<PharmacyOffer>(message);
                    newTenderOffer = CreateNewPharmacyOfferFromArrivedOffer(arrivedPharmacyOffer);

                    receivedTenderOffers.Add(newTenderOffer);
                } while (newTenderOffer != null);
            }

            return receivedTenderOffers;
        }

        private PharmacyOffer CreateNewPharmacyOfferFromArrivedOffer(PharmacyOffer arrivedPharmacyOffer)
        {
            PharmacyOffer newTenderOffer = new PharmacyOffer()
            {
                OfferIdInPharmacy = arrivedPharmacyOffer.Id,
                PharmacyId = arrivedPharmacyOffer.PharmacyId,
                TenderId = arrivedPharmacyOffer.TenderIdInHospital,
                PharmacyName = arrivedPharmacyOffer.PharmacyName,
                TimePosted = arrivedPharmacyOffer.TimePosted,
                Components = arrivedPharmacyOffer.Components
            };
            newTenderOffer.Components.ToList().ForEach(component => component.Id = 0);

            return newTenderOffer;
        }
    }
}
