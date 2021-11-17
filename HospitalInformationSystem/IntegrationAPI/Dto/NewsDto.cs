using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Dto
{
    public class NewsDto
    {
        public long Id { get; set; }
        public long IdFromPharmacy { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DurationStart { get; set; }
        public DateTime DurationEnd { get; set; }
        public bool Posted { get; set; }

        public NewsDto()
        {

        }

        public NewsDto(long idFromPharmacy, string title, string text, DateTime start, DateTime end)
        {
            IdFromPharmacy = idFromPharmacy;
            Title = title;
            Text = text;
            DurationStart = start;
            DurationEnd = end;
            Posted = false;
        }

        public NewsDto(long id, long idFromPharmacy, string title, string text, DateTime start, DateTime end)
        {
            Id = id;
            IdFromPharmacy = idFromPharmacy;
            Title = title;
            Text = text;
            DurationStart = start;
            DurationEnd = end;
            Posted = false;
        }

        public NewsDto(long id, long idFromPharmacy, string title, string text, DateTime start, DateTime end, bool posted)
        {
            Id = id;
            IdFromPharmacy = idFromPharmacy;
            Title = title;
            Text = text;
            DurationStart = start;
            DurationEnd = end;
            Posted = posted;
        }
    }
}
