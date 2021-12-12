using IntegrationClassLib.Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationClassLib.Pharmacy.Service.Interface
{
    public interface INotificationService
    {
        Notification Add(Notification notification);
        List<Notification> GetAll();
        int GetNumberNotification();
        Notification ReadNotification(Notification p);
    }
}
