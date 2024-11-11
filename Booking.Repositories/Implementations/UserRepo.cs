using Booking.Entities;
using Booking.Repositories;
using Booking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Booking.Repositories.Implementations
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserInfo> GetUserInfo(string username, string password)
        {
            var user = await _context.Userinfos.FirstOrDefaultAsync(
                x => x.UserName.ToLower() == username.ToLower() && x.Password == password);
            return user;
        }

        public async Task RegisterUser(UserInfo userInfo)
        {
            if(!Exists(userInfo.UserName))
            {
                await _context.Userinfos.AddAsync(userInfo);
                await _context.SaveChangesAsync();
            }
           
        }

        private bool Exists(string userName)
        {
            return _context.Userinfos.Any(x=>x.UserName.ToLower() == userName.ToLower());
        }
    }
}
