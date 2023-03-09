using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using new_project.Models;
using new_project.Dtos;

namespace new_project.Services
{
    public interface IUserService
    {
        Task<ServiceResponse<List<GetUserDto>>> GetUsers();
        Task<ServiceResponse<GetUserDto>> GetUser(int id);
        Task<ServiceResponse<List<GetUserDto>>> AddUser(AddUserDto newUser);
        Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updatedUser);
        Task<ServiceResponse<List<GetUserDto>>> DeteteUser(int id);
    }
}