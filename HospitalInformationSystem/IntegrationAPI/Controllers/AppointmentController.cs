using IntegrationClassLib.Equipment.Service;
using IntegrationClassLib.SharedModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Controllers
{
    public class AppointmentController
    {

        private readonly AppointmentService appointmentService;
        public AppointmentController(AppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        [HttpGet]
        public List<Appointment> GetAllAppointment()
        {
            return appointmentService.GetAllAppointments();
        }



        [HttpPost]
        [Route("appointment")]
        public Appointment CreateAppointment(Appointment appointment)
        {
            return appointmentService.CreatAppointment(appointment);
        }
    }
}
