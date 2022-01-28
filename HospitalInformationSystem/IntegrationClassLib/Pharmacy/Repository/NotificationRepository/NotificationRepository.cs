using IntegrationClassLib.Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationClassLib.Pharmacy.Repository.NotificationRepository
{
   public class NotificationRepository : AbstractSqlRepository<Notification, long>, INotificationRepository
    {
        public NotificationRepository(MyDbContext dbContext) : base(dbContext)
        {

        }
        protected override long GetId(Notification entity)
        {
            return entity.Id;
        }
    }
}
