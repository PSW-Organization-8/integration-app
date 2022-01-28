using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.SharedModel
{
    public class Manager : LoggedUser
    {
        public int VacationDays { get; set; }

        public Manager()
        {
        }

        public Manager(string name, string lastName, string jmbg, string username, string password, string email, string phone, Address address, int vacationDays) : base(name, lastName, jmbg, username, password, email, phone, address)
        {
            VacationDays = vacationDays;
        }


    }
}
