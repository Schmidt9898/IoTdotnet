using AutoMapper;
using IoTdotnet.Dtos;
using IoTdotnet.Models;
using IoTdotnet.View;
using Microsoft.AspNetCore.Mvc;

namespace IoTdotnet.Services
{
    public class IotUserService
    {
        private readonly SensorsDBContext _context;
        private readonly IMapper _mapper;

        public IotUserService(SensorsDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IotUserVM> GetUserVMByUserName(string Username)
        {
            var user_ = await GetUserByUserName(Username);
            if (user_ is null)
            {
                return null;
            }
            return _mapper.Map<IotUserVM>(user_);
        }
        public async Task<IotUser> GetUserByUserName(string Username)
        {
            var user_ = _context.users.Where(p => p.UserName == Username);
            if (user_.Count() == 0)
            {
                return null;
            }
            return user_.First();
        }

        public async Task<IotUser> CreateUserAsync(IotUserRegisterDto s)
        {
            var p = _mapper.Map<Models.IotUser>(s);

            //var user_ = await _context.users.FindAsync(p.UserId);
            //if (user_ is not null)
            //    return null;

            _context.users.Add(p);
            await _context.SaveChangesAsync();
            return p;

        }

        public async Task<bool> RemoveUserAsync(int Userid)
        {
            var user_ = _context.users.Find(Userid); //TODO remove all other tables record
            if (user_ is not null)
            {
                _context.users.Remove(user_);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }



    }
}