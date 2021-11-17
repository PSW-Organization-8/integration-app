using IntegrationAPI.Dto;
using IntegrationClassLib.Parthership.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Mapper
{
    public class NewsMapper
    {
        public static News NewsDtoToNews(NewsDto newsDto)
        {
            return new News(newsDto.Id, newsDto.IdFromPharmacy, newsDto.Title, newsDto.Text, newsDto.DurationStart, newsDto.DurationEnd, newsDto.Posted);
        }
        public static NewsDto NewsToNewsDto(News news)
        {
            return new NewsDto(news.Id, news.IdFromPharmacy, news.Title, news.Text, news.DurationStart, news.DurationEnd, news.Posted);
        }
    }
}
