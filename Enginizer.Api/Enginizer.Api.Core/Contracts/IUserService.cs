using Enginizer.Api.Core.Models.ViewModels.User;

namespace Enginizer.Api.Core.Contracts
{
    public interface IUserService
    {
        Task<UserViewModel> GetUserById(int id);
        Task<List<UserViewModel>> GetAllUsersAsync();
        Task<UserViewModel> AddUserASync(UserViewModel user);
        Task<UserViewModel> UpdateUserAsync(UserUpdateViewModel user);
        Task<int> DeleteUserAsync(int id);
    }
}
