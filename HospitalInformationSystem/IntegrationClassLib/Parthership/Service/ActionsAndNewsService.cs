using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationClassLib.Parthership.Model;
using IntegrationClassLib.Parthership.Repository;
using IntegrationClassLib.Parthership.Service.Interface;

namespace IntegrationClassLib.Parthership.Service
{
    public class ActionsAndNewsService : IActionsAndNewsService
    {
        private readonly INewsRepository newsRepository;
        private readonly IReceivingNewsService receivingNewsService;

        public ActionsAndNewsService(INewsRepository newsRepository, IReceivingNewsService receivingNewsService)
        {
            this.newsRepository = newsRepository;
            this.receivingNewsService = receivingNewsService;
        }

        public List<News> GetAllActionsAndNews()
        {
            CreateAllReceivedNews(LookForNewActionsAndNews());
            return newsRepository.GetAll();
        }

        public void CreateAllReceivedNews(List<News> allNewNews)
        {
            foreach (News newNews in allNewNews)
            {
                CreateNews(newNews);
            }
        }

        public News CreateNews(News newNews)
        {
            newNews.Posted = false;
            return newsRepository.Create(newNews);
        }


        private List<News> LookForNewActionsAndNews()
        {
            return receivingNewsService.ReceiveActionsAndNews();
        }

        public News ApproveNews(News news)
        {
            news.Posted = true;
            return newsRepository.Update(news);
        }

        public News UnapproveNews(News news)
        {
            news.Posted = false;
            return newsRepository.Update(news);
        }
    }
}
