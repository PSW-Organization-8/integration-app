﻿using System.Collections;
using System.Collections.Generic;
using IntegrationClassLib.Tendering.Model;
using SIMS.Repositories;

namespace IntegrationClassLib.Tendering.Repository
{
    public interface ITenderingRepository: IGenericRepository<Tender, long>
    {
        List<Tender> GetAllWithMedications();
        List<Tender> GetByName(string name);
    }
}
