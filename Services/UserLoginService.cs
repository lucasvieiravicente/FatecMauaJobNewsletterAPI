using FatecMauaJobNewsletter.Domains;
using FatecMauaJobNewsletter.Domains.Models;
using FatecMauaJobNewsletter.Domains.Utils;
using FatecMauaJobNewsletter.Repositories.Interfaces;
using FatecMauaJobNewsletter.Services.Interfaces;
using Mapster;
using System.Threading.Tasks;

namespace FatecMauaJobNewsletter.Services
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly TypeAdapterConfig _mapConfig = ConfigMapster.Configs();

        public UserLoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public LoginResponse LoginRequest(LoginRequest request)
        {
            User userRegister = _userRepository.FindByLogin(request.Login, HashUtil.HashPassword(request.Password));

            if (!(userRegister is null))
                return new LoginResponse(TokenUtil.GenerateTokenJWT(userRegister));
            else
                return null;
        }

        public async Task RegisterUser(SignUpRequest request)
        {
            User user = request.Adapt<User>(_mapConfig);
            user.UserType = UserType.Student;
            await _userRepository.InsertAsync(user);
        }

        public async Task RegisterAdministrationUser(SignUpRequest request)
        {
            var user = request.Adapt<User>(_mapConfig);
            user.UserType = UserType.Administration;
            await _userRepository.InsertAsync(user);
        }
    }
}
