using FatecMauaJobNewsletter.Domains.Models;
using FatecMauaJobNewsletter.Domains.Models.Request;
using System.Threading.Tasks;

namespace FatecMauaJobNewsletter.Services.Interfaces
{
    public interface IUserLoginService
    {
        LoginResponse LoginRequest(LoginRequest request);

        Task RegisterUser(SignUpRequest request);

        Task RegisterAdministrationUser(SignUpRequest request);

        Task UpdateUser(UserUpdate request);

        UserUpdate GetUserByLogin();
    }
}
