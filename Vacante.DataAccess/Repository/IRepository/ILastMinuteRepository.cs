using System;
using VacanteAPP.Models;

namespace Vacante.DataAccess.Repository.IRepository
{
    public interface ILastMinuteRepository : IRepository<LastMinute>
    {
        void Update(LastMinute lastMinute);


    }
}

