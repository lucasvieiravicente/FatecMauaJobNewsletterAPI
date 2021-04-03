namespace FatecMauaJobNewsletter.Services.Interfaces
{ 
    public interface ICookiesService
    {
        void SetLoginCookie(string jwtToken);

        void RemoveLoginCookie();

        bool IsLogged();

        bool IsAdmin();

        string GetJwtToken();
    }
}
