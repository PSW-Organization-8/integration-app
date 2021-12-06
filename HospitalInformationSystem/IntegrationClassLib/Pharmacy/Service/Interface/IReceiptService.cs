using IntegrationClassLib.Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Pharmacy.Service.Interface
{
    public interface IReceiptService
    {
        string CreateReceipt(Receipt receipt, Pharmacy.Model.Pharmacy pharmacy);

    }
}
