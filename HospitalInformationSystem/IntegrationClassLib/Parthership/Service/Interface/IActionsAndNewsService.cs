using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationClassLib.Parthership.Model;

namespace IntegrationClassLib.Parthership.Service.Interface
{
    public interface IActionsAndNewsService
    {
        News CreateNews(News newNews);
        void CreateAllReceivedNews(List<News> allNewNews);
        List<News> GetAllActionsAndNews();
        News ApproveNews(News news);
        News UnapproveNews(News news);
    }
}
