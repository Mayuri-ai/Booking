using Booking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repositories.Interfaces
{
    public interface IArtistRepo
    {
        Task<IEnumerable<Artist>> GetAll();
        Task<Artist> GetById(int id);
        Task Save(Artist artist);
        Task Edit(Artist artist);
        Task RemoveData(Artist artist);
    }
}
