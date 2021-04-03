using FatecMauaJobNewsletter.Models.Pages;
using System.Threading.Tasks;

namespace FatecMauaJobNewsletter.Services.Interfaces
{
    public interface IPagesService
    {
        Task<Address> GetNeighborhoodByZipCode(string zipCode);

        Task<City[]> GetCities(string stateId);

        Task<State[]> GetStates();
    }
}
