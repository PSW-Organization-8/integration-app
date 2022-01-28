
using IntegrationAPI.Controllers;
using IntegrationAPI.Dto;
using IntegrationClassLib;
using IntegrationClassLib.Pharmacy.Model;
using IntegrationClassLib.Pharmacy.Repository.NotificationRepository;
using IntegrationClassLib.Pharmacy.Service;
using IntegrationClassLib.Pharmacy.Service.Interface;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class NotificationTests
    {
        private NotificationController GetNotificationController()
        {
            MyDbContext dbContext = new MyDbContext();
            INotificationRepository notificationRepository = new NotificationRepository(dbContext);
            INotificationService notificationService = new NotificationService(notificationRepository);
            NotificationController controller = new NotificationController(notificationService);
            return controller;
        }
        [Fact]
        public void Cant_create_notification()
        {
            NotificationController controller = GetNotificationController();
            NotificationDTO dto = new NotificationDTO
            {
                Title = "Neki novi title",
                Read = false,
                ContentNotification = "Ovde ce da bude napisan neki tekst o pdf",
                FileName = "MedicationConsumption.pdf"
            };

            Notification retVal = controller.Add(dto);

            retVal.ShouldNotBe(null);
        }
    }
}
