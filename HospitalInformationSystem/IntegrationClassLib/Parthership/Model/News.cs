using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Parthership.Model
{
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long IdFromPharmacy { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DurationStart { get; set; }
        public DateTime DurationEnd { get; set; }
        public bool Posted { get; set; }

        public News()
        {

        }

        public News(long idFromPharmacy, string title, string text, DateTime start, DateTime end)
        {
            IdFromPharmacy = idFromPharmacy;
            Title = title;
            Text = text;
            DurationStart = start;
            DurationEnd = end;
            Posted = false;
        }

        public News(long id, long idFromPharmacy, string title, string text, DateTime start, DateTime end)
        {
            Id = id;
            IdFromPharmacy = idFromPharmacy;
            Title = title;
            Text = text;
            DurationStart = start;
            DurationEnd = end;
            Posted = false;
        }

        public News(long id, long idFromPharmacy, string title, string text, DateTime start, DateTime end, bool posted)
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
