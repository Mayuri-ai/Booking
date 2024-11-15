﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;

namespace Booking.WebHost.ViewModels.AccountViewModel
{
    public class UserInfoViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
