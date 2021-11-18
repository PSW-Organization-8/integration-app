using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationClassLib.Parthership.Model;
using IntegrationClassLib.Parthership.Repository;

namespace IntegrationTests.InMemoryRepository
{
    public class NewsTestRepository : INewsRepository
    {
        private Dictionary<long, News> allNews = new Dictionary<long, News>();

        public NewsTestRepository()
        {
            allNews.Add(1, new News(1, 5, "Dobar naslov", "Vrlo opsiran tekst", DateTime.Now, DateTime.Now, false));
            allNews.Add(3, new News(3, 6, "Mega popust", "Na sve proizvode", DateTime.Now, DateTime.Now, true));
        }

        public List<News> GetAll()
        {
            return allNews.Values.ToList();
        }

        public News Get(long id)
        {
            return allNews[id];
        }

        public News Update(News t)
        {
            allNews[t.Id] = t;
            return allNews[t.Id];
        }

        public News Create(News t)
        {
            allNews.Add(t.Id, t);
            return allNews[t.Id];
        }

        public bool ExistsById(long id)
        {
            return allNews.ContainsKey(id);
        }

        public bool Delete(long id)
        {
            return allNews.Remove(id);
        }
    }
}
