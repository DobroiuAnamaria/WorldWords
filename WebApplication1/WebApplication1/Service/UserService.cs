
using AutoMapper;
using WebApplication1.Model;
using WebApplication1.Repository;

namespace WebApplication1.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)

        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserViewModel>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserViewModel>>(users);

        }

        public async Task<UserViewModel> GetUserById(int id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<UserViewModel> AddUserASync(UserViewModel user)
        {
            await _userRepository.AddAsync(_mapper.Map<User>(user));
            return user;
        }

        public async Task<UserViewModel> UpdateUserAsync(UserUpdateViewModel request)
        {
            var user = await _userRepository.FindByIdAsync(request.Id);
            if (user is null)
            {
                throw new Exception();
            }
            user.Name = request.Name;
            user.Email = request.Email;
            user.Password = request.Password;

            await _userRepository.UpdateAsync(user);
            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<int> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }

    }
}
