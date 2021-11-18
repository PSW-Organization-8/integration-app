using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationClassLib.Parthership.Model;
using IntegrationClassLib.Parthership.Repository;
using IntegrationClassLib.Parthership.Service;
using IntegrationClassLib.Parthership.Service.Interface;
using IntegrationTests.InMemoryRepository;
using Moq;
using Shouldly;
using Xunit;

namespace IntegrationTests.UnitTests
{
    public class NewsAndActionsTests
    {
        private INewsRepository newsRepository;
        private IReceivingNewsService receivingNewsService;
        private IActionsAndNewsService actionsAndNewsService;
        private readonly long ID_OF_APPROVED_NEWS = 3;
        private readonly long ID_OF_UNAPPROVED_NEWS = 1;


        [Fact]
        public void Message_receiving_and_storing()
        {
            PrepareServicesForReceivingTests();

            List<News> allNews = actionsAndNewsService.GetAllActionsAndNews();

            allNews.Count.ShouldBe(4);
        }

        private void PrepareServicesForReceivingTests()
        {
            newsRepository = new NewsTestRepository();
            var stubReceivingNewsService = new Mock<IReceivingNewsService>();
            News receivedNews1 = new News(10, 11, "Nova novost", "Veoma dobra akcija u svim nasim apotekama!", DateTime.Now, DateTime.Now, false);
            News receivedNews2 = new News(12, 13, "AKCIJA", "Mnogo novih pogodnosti!", DateTime.Now, DateTime.Now, false);
            List<News> allReceivedNews = new List<News>();
            allReceivedNews.Add(receivedNews1);
            allReceivedNews.Add(receivedNews2);
            stubReceivingNewsService.Setup(m => m.ReceiveActionsAndNews()).Returns(allReceivedNews);
            actionsAndNewsService = new ActionsAndNewsService(newsRepository, stubReceivingNewsService.Object);
        }

        [Fact]
        public void Approving_actions_and_news()
        {
            PrepareServicesForApprovalTests();
            News unapprovedNews = newsRepository.Get(ID_OF_UNAPPROVED_NEWS);

            actionsAndNewsService.ApproveNews(unapprovedNews);

            newsRepository.Get(1).Posted.ShouldBe(true);
        }

        [Fact]
        public void Unapproving_actions_and_news()
        {
            PrepareServicesForApprovalTests();
            News approvedNews = newsRepository.Get(ID_OF_APPROVED_NEWS);

            actionsAndNewsService.UnapproveNews(approvedNews);

            newsRepository.Get(3).Posted.ShouldBe(false);
        }

        private void PrepareServicesForApprovalTests()
        {
            newsRepository = new NewsTestRepository();
            receivingNewsService = new ReceivingNewsRabbitMQService();
            actionsAndNewsService = new ActionsAndNewsService(newsRepository, receivingNewsService);
        }
    }
}
