using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationClassLib.Parthership.Model;
using IntegrationClassLib.Parthership.Service.Interface;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace IntegrationClassLib.Parthership.Service
{
    public class ReceivingNewsRabbitMQService : IReceivingNewsService
    {
        private readonly string _hostName = Environment.GetEnvironmentVariable("RabbitHostName") ?? "localhost";
        private readonly string _hospitalName = "Bolnica1";

        public List<News> ReceiveActionsAndNews()
        {
            List<News> receivedNews = new List<News>();
            var factory = new ConnectionFactory() { HostName = _hostName };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "newsExchange", type: ExchangeType.Fanout);

                News newNews = null;
                do
                {
                    var basicGetResult = channel.BasicGet(_hospitalName, true);     // prvi parametar je od kojeg reda se uzima poruka
                    if (basicGetResult == null)
                    {
                        newNews = null;
                        continue;
                    }
                    var body = basicGetResult.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    News arrivedNews = JsonConvert.DeserializeObject<News>(message);
                    newNews = CreateNewNewsFromArrivedNews(arrivedNews);
                    receivedNews.Add(newNews);
                } while (newNews != null);
            }

            return receivedNews;
        }

        private News CreateNewNewsFromArrivedNews(News arrivedNews)
        {
            News newNews = new News()
            {
                IdFromPharmacy = arrivedNews.Id,
                Title = arrivedNews.Title,
                Text = arrivedNews.Text,
                DateRange = new IntegrationClassLib.Model.DateRange(arrivedNews.DateRange.Start, arrivedNews.DateRange.End),
                Posted = false
            };

            return newNews;
        }
    }
}
