using IntegrationClassLib.Tendering.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.ModelConfiguration
{
    public class TenderConfiguration: IEntityTypeConfiguration<Tender>
    {
        public void Configure(EntityTypeBuilder<Tender> builder)
        {
            builder.ToTable("Tenders");
            builder.HasKey(tenders => tenders.Id);
            builder.OwnsOne(tenders => tenders.DateRange);
        }
    }
}
