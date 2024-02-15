using MAUI.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Services;


public interface IUserService
{
    Task<User> GetUserById(string UserId);
    Task<List<User>> GetAllUsers();

}

internal class UserService : IUserService
{
    readonly IApiRequestHelper _apiRequestHelper;
    public UserService(IApiRequestHelper apiRequestHelper)
    {
        _apiRequestHelper = apiRequestHelper;
    }

    public async Task<User> GetUserById(string UserId)
    {
        var result = await _apiRequestHelper.SendAsync<User>(HttpMethod.Post, ApiNames.CentralAPI, "/users", UserId);

        return result ?? new();
    }

    public async Task<List<User>> GetAllUsers()
    {
        var result = await _apiRequestHelper.GetAsync<List<User>>(ApiNames.CentralAPI, "/users");

        return result ?? new();
    }

    
}
