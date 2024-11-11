using Booking.Entities;
using Booking.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repositories.Implementations
{
    public class BookingRepo : IBookingRepo
    {
        private readonly ApplicationDbContext _context;

        public BookingRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddBooking(Bookiing booking)
        {
           await _context.Bookings.AddAsync(booking);
          await  _context.SaveChangesAsync();
        }
    }
}
