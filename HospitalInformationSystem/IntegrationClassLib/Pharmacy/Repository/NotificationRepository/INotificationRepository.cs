using IntegrationClassLib.Pharmacy.Model;
using SIMS.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationClassLib.Pharmacy.Repository.NotificationRepository
{
    public interface INotificationRepository:IGenericRepository<Notification, long>
    {
    }
}
