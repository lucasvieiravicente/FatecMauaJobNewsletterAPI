using FatecMauaJobNewsletter.Domains.Utils;
using FatecMauaJobNewsletter.Models.Pages;
using FatecMauaJobNewsletter.Services.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FatecMauaJobNewsletter.Services
{
    public class PagesService : IPagesService
    {
        public async Task<State[]> GetStates()
        {
            var httpClient = new HttpClient();
            Uri uri = new Uri("https://servicodados.ibge.gov.br/api/v1/localidades/estados?orderBy=nome");

            try
            {
                var result = await httpClient.GetAsync(uri);

                if (result.IsSuccessStatusCode)
                    return await result.Content.FormatContentTo<State[]>();
                else
                    throw new Exception("Não foi possível obter os estados");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<City[]> GetCities(string stateId)
        {
            var httpClient = new HttpClient();
            Uri uri = new Uri($"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{stateId}/municipios");

            try
            {
                var result = await httpClient.GetAsync(uri);

                if (result.IsSuccessStatusCode)
                    return await result.Content.FormatContentTo<City[]>();
                else
                    throw new Exception("Não foi possível obter as cidades");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Address> GetNeighborhoodByZipCode(string zipCode)
        {
            var httpClient = new HttpClient();
            Uri uri = new Uri($"https://viacep.com.br/ws/{zipCode}/json/");

            try
            {
                var result = await httpClient.GetAsync(uri);

                if (result.IsSuccessStatusCode)
                    return await result.Content.FormatContentTo<Address>();
                else
                    throw new Exception("Não foi possível obter os bairros");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
