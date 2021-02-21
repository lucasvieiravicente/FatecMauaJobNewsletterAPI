using FatecMauaJobNewsletter.Domains.Models;
using System.Threading.Tasks;

namespace FatecMauaJobNewsletter.Services.Interfaces
{
    public interface IUserLoginService
    {
        LoginResponse LoginRequest(LoginRequest request);

        Task RegisterUser(SignUpRequest request);

        Task RegisterAdministrationUser(SignUpRequest request);
    }
}
