using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NedoNet.API.BindingModels;
using NedoNet.API.Models;

namespace NedoNet.API.Services {
    public interface IUsersService {
        Task<List<UserViewModel>> GetAllUsersAsync(  );
        Task<UserViewModel> GetUserAsync(Guid id);
        UserViewModel CreateUser(UserBindingModel model);
        Task<UserViewModel> UpdateUserAsync(Guid userId, UserBindingModel model);
        Task DeleteUserAsync(Guid userId);
    }
}