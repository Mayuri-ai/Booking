using Booking.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repositories.Interfaces
{
    public interface IConcertRepo
    {
        Task<IEnumerable<Concert>> GetAll();
        Task<Concert> GetById(int id);
        Task Save(Concert concert);
        Task Edit(Concert concert);
        Task RemoveData(Concert concert);
    }
}
