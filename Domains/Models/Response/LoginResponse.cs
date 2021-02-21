namespace FatecMauaJobNewsletter.Domains.Models
{
    public class LoginResponse
    {
        public LoginResponse(string jwtResponse)
        {
            JwtResponse = jwtResponse;
        }

        public string JwtResponse { get; set; }
    }
}
