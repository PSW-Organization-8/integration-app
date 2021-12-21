using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Parthership.Service.Interface
{
    public interface IChannelsForCommunication
    {
        void CreateAllChannels();
        void CreateChannelsForPharmacy(Pharmacy.Model.Pharmacy pharmacy);
    }
}
