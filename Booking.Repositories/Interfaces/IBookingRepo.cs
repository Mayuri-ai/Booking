using Booking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repositories.Interfaces
{
    public interface IBookingRepo
    {
        Task AddBooking(Bookiing booking);
    }
}
