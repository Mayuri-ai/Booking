﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Entities
{
    public class Bookiing
    {
        [Key] 
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public int ConcertId { get; set; }
        public Concert Concert { get; set; }
        public string UserId { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
