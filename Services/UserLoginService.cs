using FatecMauaJobNewsletter.Domains.Utils;
using Mapster;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using FatecMauaJobNewsletter.Services.Interfaces;
using FatecMauaJobNewsletter.Repositories.Interfaces;
using FatecMauaJobNewsletter.Domains.Models;
using FatecMauaJobNewsletter.Domains.Enums;
using FatecMauaJobNewsletter.Domains.Consts;

namespace FatecMauaJobNewsletter.Services
{
    public class UserLoginService : BaseService, IUserLoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly ICookiesService _cookiesService;
        private readonly TypeAdapterConfig _mapConfig = ConfigMapster.Configs();

        public UserLoginService(
                IUserRepository userRepository, 
                IConfiguration configuration, 
                ICookiesService cookiesService,
                IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _cookiesService = cookiesService;
        }

        public LoginResponse LoginRequest(LoginRequest request)
        {
            User userRegister = _userRepository.FindByLoginAndPassword(request.Login, HashUtil.HashPassword(request.Password));

            if (userRegister is null)
                throw new Exception("Usuário não localizado");      

            var response = new LoginResponse(TokenUtil.GenerateTokenJWT(userRegister, _configuration));

            if (userRegister.UserType == UserType.Administration)
                response.IsAdmin = true;

            return response;
        }

        public async Task RegisterUser(SignUpRequest request)
        {
            User userRegistered = _userRepository.FindByLogin(request.Login);

            if (userRegistered != null)
                throw new Exception("Login já cadastrado");

            User user = request.Adapt<User>(_mapConfig);
            AuditHelper.UpdateAuditInfo(user, EntityState.Added, SystemUsers.System);
            user.UserType = UserType.Student;
            await _userRepository.InsertAsync(user);
        }

        public async Task RegisterAdministrationUser(SignUpRequest request)
        {
            User userRegistered = _userRepository.FindByLogin(request.Login);

            if (userRegistered != null)
                throw new Exception("Login já cadastrado");

            var user = request.Adapt<User>(_mapConfig);
            AuditHelper.UpdateAuditInfo(user, EntityState.Added, SystemUsers.System);
            user.UserType = UserType.Administration;
            await _userRepository.InsertAsync(user);
        }
    }
}
