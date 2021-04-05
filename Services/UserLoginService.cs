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
using FatecMauaJobNewsletter.Domains.Models.Request;

namespace FatecMauaJobNewsletter.Services
{
    public class UserLoginService : BaseService, IUserLoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly TypeAdapterConfig _mapConfig = ConfigMapster.Configs();

        public UserLoginService(
                IUserRepository userRepository, 
                IConfiguration configuration, 
                IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _userRepository = userRepository;
            _configuration = configuration;
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

        public async Task UpdateUser(UserUpdate request)
        {
            User userRegistered = _userRepository.FindByLogin(GetLogin());

            if (userRegistered is null)
                throw new Exception("Usuário não localizado, contate o administrador do sistema");

            SetUserInfos(userRegistered, request);
            AuditHelper.UpdateAuditInfo(userRegistered, EntityState.Modified, GetName());
            await _userRepository.UpdateAsync(userRegistered);
        }

        public UserUpdate GetUserByLogin()
        {
            User userRegistered = _userRepository.FindByLogin(GetLogin());

            if (userRegistered is null)
                throw new Exception("Usuário não localizado, contate o administrador do sistema");

            return userRegistered.Adapt<UserUpdate>(_mapConfig);
        }

        private void SetUserInfos(User userRegistered, UserUpdate request)
        {
            if(!string.IsNullOrEmpty(request.Name))
                userRegistered.Name = request.Name;

            if (!string.IsNullOrEmpty(request.Email))
                userRegistered.Email = request.Email;

            if (!string.IsNullOrEmpty(request.PhoneNumber))
                userRegistered.PhoneNumber = request.PhoneNumber;

            if (!string.IsNullOrEmpty(request.Password))
                userRegistered.Password = HashUtil.HashPassword(request.Password);
        }
    }
}
