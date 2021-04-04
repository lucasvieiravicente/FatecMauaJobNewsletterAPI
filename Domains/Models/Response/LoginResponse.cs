namespace FatecMauaJobNewsletter.Domains.Models
{
    public class LoginResponse
    {
        public LoginResponse()
        {

        }

        public LoginResponse(string jwtToken)
        {
            JwtToken = jwtToken;
        }

        public bool IsAdmin { get; set; }

        public string JwtToken { get; set; }
    }
}
