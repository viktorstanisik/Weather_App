using WeatherApp_Service.Models;

namespace WeatherApp_Service.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(LoginModel model, int id);

    }
}
