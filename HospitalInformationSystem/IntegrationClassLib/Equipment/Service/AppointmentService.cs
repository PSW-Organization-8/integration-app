using IntegrationClassLib.Equipment.Repository.IRepository;
using IntegrationClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Equipment.Service
{
        public class AppointmentService
        {
            private readonly IAppointmentRepository appointmentRepository;


            public AppointmentService(IAppointmentRepository appoitmentRepository)
            {
                this.appointmentRepository = appoitmentRepository;

            }

            public List<Appointment> GetAllAppointments()
            {
                return appointmentRepository.GetAll();
            }

            public Appointment CreatAppointment(Appointment newAppointment)
            {
                return appointmentRepository.Create(newAppointment);
            }

        }

}
