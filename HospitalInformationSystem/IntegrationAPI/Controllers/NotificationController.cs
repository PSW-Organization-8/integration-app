using IntegrationAPI.Dto;
using IntegrationAPI.Mapper;
using IntegrationClassLib.Pharmacy.Model;
using IntegrationClassLib.Pharmacy.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService notificationService;
        private NotificationMapper mapper = new NotificationMapper();
        public NotificationController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
       
        }
        [HttpPost]
         public Notification Add(NotificationDTO notification)
        {
             return notificationService.Add(mapper.NotificationDTOToNotification(notification));
        }
        [HttpGet]
        [Route("number")]

        public int GetNumberNotification()
        {
           return notificationService.GetNumberNotification(); 
        }
        [HttpGet]

        public List<Notification> GetAllNotification()
        {

            return notificationService.GetAll();
        }

        [HttpPut]
        [Route("read")]
        public IActionResult ReadNotification(NotificationDTO notification, long id = 0)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            return Ok(notificationService.ReadNotification(mapper.NotificationDTOToNotification(notification)));
        }
    }
}
