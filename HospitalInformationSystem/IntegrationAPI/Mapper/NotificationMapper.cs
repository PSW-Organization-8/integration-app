using IntegrationAPI.Dto;
using IntegrationClassLib.Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Mapper
{
    public class NotificationMapper
    {
        public Notification NotificationDTOToNotification(NotificationDTO dto)
        {
            return new Notification(dto.Id,dto.Title,dto.Read,dto.ContentNotification,dto.FileName);
        }
    }
}
