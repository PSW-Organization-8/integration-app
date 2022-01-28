using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Connection.Interface
{
    public interface IPharmacySFTPConnection
    {
        void SendReceiptToPharmacy(string path);

    }
}
