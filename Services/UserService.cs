using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using new_project.Models;
using new_project.Dtos;
using AutoMapper;
using new_project.Data;
using Microsoft.EntityFrameworkCore;

namespace new_project.Services
{   
    public class UserService : IUserService
    {
        // Testing Data
        private static List<User> users = new List<User> {
            new User{ userid = 1, namalengkap = "Giffari Yusrul K", username = "giffari_yk", password = "password", status = "single" },
            new User{ userid = 2, namalengkap = "Yusrul K Giffari", username = "yk_giffari", password = "password", status = "single" }
        };

        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public UserService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> GetUsers()
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();

            var dbUsers = await _context.Users.ToListAsync();

            serviceResponse.data = dbUsers.Select(user => _mapper.Map<GetUserDto>(user)).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetUserDto>> GetUser(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();

            var dbUser = await _context.Users.FirstOrDefaultAsync(user => user.userid == id);
            
            serviceResponse.data = _mapper.Map<GetUserDto>(dbUser);
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetUserDto>>> AddUser(AddUserDto newUser)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            
            var user = _mapper.Map<User>(newUser);

            var dbUsers = await _context.Users.ToListAsync();

            user.userid = dbUsers.Max(user => user.userid) + 1;

            await _context.Users.AddAsync(user);

            _context.SaveChanges();

            dbUsers = await _context.Users.ToListAsync();

            serviceResponse.data = dbUsers.Select(user => _mapper.Map<GetUserDto>(user)).ToList();
            return serviceResponse;
        }

        // Not connected to DB
        public async Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updatedUser)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();

            try
            {
                var user = users.FirstOrDefault(user => user.userid == updatedUser.userid);
                if (user is null)
                    throw new Exception($"User with id '{updatedUser.userid}' not found");

                user.namalengkap = updatedUser.namalengkap;
                user.username = updatedUser.username;
                user.password = updatedUser.password;
                user.status = updatedUser.status;

                serviceResponse.data = _mapper.Map<GetUserDto>(user);
            }
            catch (Exception ex)
            {
                
                serviceResponse.success = false;
                serviceResponse.message = ex.Message; 
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> DeteteUser(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();

            try
            {
                var dbUser = await _context.Users.FirstOrDefaultAsync(user => user.userid == id);

                if (dbUser is null)
                    throw new Exception($"User with id '{id}' not found");

                await _context.Users
                .Where(user => user.userid == id)
                .ExecuteDeleteAsync();

                var dbUsers = await _context.Users.ToListAsync();

                serviceResponse.data = dbUsers.Select(user => _mapper.Map<GetUserDto>(user)).ToList();
            }
            catch (Exception ex)
            {
                
                serviceResponse.success = false;
                serviceResponse.message = ex.Message; 
            }

            return serviceResponse;
        }
    }
}